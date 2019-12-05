using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.U2D;

public class Hole : MonoBehaviour
{
    public float destructionTime = 5f;
    private SpriteShapeController _spriteShape;
    private void Start()
    {
        _spriteShape = GetComponent<SpriteShapeController>();
        Destroy(gameObject,destructionTime);
    }
}