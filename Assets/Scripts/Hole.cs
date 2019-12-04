using System;
using System.Collections;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float destructionTime = 5f;
    private MeshFilter _meshFilter;
    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();

        if (_meshFilter.mesh.bounds.size.magnitude < 1)
            destructionTime = 0f;
        
        Destroy(gameObject,destructionTime);
    }
}