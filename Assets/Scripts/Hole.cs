using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.U2D;

public class Hole : MonoBehaviour
{
    public float destructionTime = 5f;
    public float delayActivation = 1f;
    private bool _isCActive = false;
    private SpriteShapeController _spriteShape;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!_isCActive)
            return;
        Debug.Log("You ded");
    }
}