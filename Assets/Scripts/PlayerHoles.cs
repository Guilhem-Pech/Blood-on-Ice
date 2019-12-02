using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHoles : MonoBehaviour
{
    [SerializeField]
    private Vector3[] vertexPos;
    private TrailRenderer _trailRenderer;
    private EdgeCollider2D _edgeCollider2D;
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

    private void CloseHole(Vector3 pos)
    {

        List<Vector3> vPos = new List<Vector3>(vertexPos);
        int findIndex = vPos.FindIndex(x => Mathf.Abs(Vector2.Distance(x,pos)) <= 0.08);
        vPos.RemoveRange(0,findIndex);
        vPos[vPos.Count - 1] = vPos[0];
        
        GameObject hole = Instantiate(holePrefab, transform.position, Quaternion.identity);
        LineRenderer line = hole.GetComponent<LineRenderer>();
        line.positionCount = vPos.Count;
        line.SetPositions(vPos.ToArray());
        _trailRenderer.Clear();
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 pos = _edgeCollider2D.ClosestPoint(other.transform.position);
        CloseHole(pos);
    }

}