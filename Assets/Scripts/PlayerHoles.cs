using System;
using UnityEngine;

public class PlayerHoles : MonoBehaviour
{
    [SerializeField]
    private Vector3[] vertexPos;
    private TrailRenderer _trailRenderer;
    private EdgeCollider2D _edgeCollider2D;

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
}