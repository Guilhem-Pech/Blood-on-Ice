using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoles : MonoBehaviour
{
    [SerializeField]
    private Vector3[] vertexPos;
    private TrailRenderer _trailRenderer;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        Vector3[] linepos = new Vector3[_trailRenderer.positionCount];
        _trailRenderer.GetPositions(linepos);
        vertexPos = linepos;
    }
}
