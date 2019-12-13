using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.U2D;

public class Hole : MonoBehaviour
{
    public float destructionTime = 5f;
    public float delayActivation = 1f;
    private bool _isCActive = false;
    private SpriteShapeController _spriteShape;
    public IList<Vector3> vertexPos;
    
    public GameObject vortexPrefab;
    private GameObject _vortex;

    private void Start()
    {
        _spriteShape = GetComponent<SpriteShapeController>();
        Destroy(gameObject,destructionTime);
        StartCoroutine(StartTrigger(delayActivation));
    }

    private IEnumerator StartTrigger(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isCActive = true;
        Vector3 pos = AvgVector(vertexPos);
        pos.z = 5;
        _vortex = Instantiate(vortexPrefab, pos, Quaternion.identity);
    }

    private void OnDestroy()
    {
       // Destroy(_vortex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!_isCActive)
            return;
        Debug.Log("You ded");
    }
    
    
    private static Vector2 AvgVector(ICollection<Vector3> vertex)
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
}