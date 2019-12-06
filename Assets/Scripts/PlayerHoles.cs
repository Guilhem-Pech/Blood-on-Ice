using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerHoles : MonoBehaviour
{
    [SerializeField]
    private Vector3[] vertexPos;
    private TrailRenderer _trailRenderer;
    private EdgeCollider2D _edgeCollider2D;
    public Collider2D _playerCollider2D;
    [SerializeField] [CanBeNull] private GameObject holePrefab;


    private void Start()
    {
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        Vector3[] linepos = new Vector3[_trailRenderer.positionCount];
        _trailRenderer.GetPositions(linepos);
        vertexPos = linepos;

        if (linepos.Length < 5) return;
        Vector2[] colliderPoints =  new Vector2[linepos.Length-5];
        for (int i = 0; i < linepos.Length - 5 ; i++)
        {
            colliderPoints[i] = transform.InverseTransformPoint(linepos[i]);
        }
        
        _edgeCollider2D.points = colliderPoints;
       
    }

    private void CloseHole(Vector3 pos, List<Vector3> vPos)
    {
        int findIndex = FindIndex(pos, vPos);
        if(findIndex == -1)
            return;
        
        vPos.RemoveRange(0,findIndex);
        vPos[vPos.Count - 1] = vPos[0];
        
        GameObject hole = Instantiate(holePrefab, Vector3.zero, Quaternion.identity);

        SpriteShapeController spriteShapeController = hole.GetComponent<SpriteShapeController>();
        Spline spline = spriteShapeController.spline;
        for (int i = 0; i < vPos.Count - 1; ++i)
        {
            if (i < spline.GetPointCount())
            {
                spline.SetPosition(i,vPos[i]);
            }
            else
            {
                spline.InsertPointAt(i, vPos[i]);
            }
        }
        
        _trailRenderer.Clear();
        StartCoroutine(DisableTrailFor(3f));

    }

    private static int FindIndex(Vector3 pos, List<Vector3> vPos, float defDist = 0.1f , float maxDist = 0.2f)
    {
        int findIndex =  vPos.FindIndex(x => Mathf.Abs(Vector2.Distance(x, pos)) <= defDist);
        while (findIndex == -1 && defDist <= maxDist)
        {
            defDist += 0.05f;
            findIndex = vPos.FindIndex(x => Mathf.Abs(Vector2.Distance(x, pos)) <= defDist);
        }
        return findIndex;
    }


    IEnumerator DisableTrailFor(float second)
    {
        _trailRenderer.enabled = false;
        yield return new WaitForSeconds(second);
        _trailRenderer.enabled = true;
        
    }
    
    
    /**
     * Old version with mesh
     
    private static Vector2[] Vec3ToVec2(IReadOnlyList<Vector3> tab)
    {
        Vector2[] result = new Vector2[tab.Count];
        for (int i = 0; i < tab.Count; i++)
        {
            result[i] = tab[i]; 
        }

        return result;
    }
    
    private static List<int> CreateTriangles(ICollection vertex)
    {
        int originPoint = vertex.Count - 1;
        List<int> result = new List<int>(6*originPoint);
        for (int i = 0; i < originPoint; i++)
        {
            result.Add((i+1) % originPoint );
            result.Add(i);
            result.Add(originPoint);
            
            result.Add((i+1) % originPoint );
            result.Add(originPoint);
            result.Add(i);
        }
        return result;
    }

    private static Vector2 AvgVector(IReadOnlyCollection<Vector3> vertex)
    {
        Vector2 avg = Vector2.zero;
        foreach (Vector3 v in vertex)
        {
            avg.x += v.x;
            avg.y += v.y;
        }

        avg.x /= vertex.Count;
        avg.y /= vertex.Count;
        return avg;
    }
    **/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_playerCollider2D != other)
            return;
        Vector3 pos = _edgeCollider2D.ClosestPoint(other.transform.position);
        CloseHole(pos, new List<Vector3>(vertexPos));
    }

}