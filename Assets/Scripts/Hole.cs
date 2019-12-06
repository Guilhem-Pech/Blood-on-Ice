using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.U2D;

public class Hole : MonoBehaviour
{
    public float destructionTime = 5f;
    public float delayActivation = 1f;
    private bool isCActive = false;
    private SpriteShapeController _spriteShape;

    private void Start()
    {
        _spriteShape = GetComponent<SpriteShapeController>();
        Destroy(gameObject,destructionTime);
        StartCoroutine(StartTrigger(1f));
    }

    IEnumerator StartTrigger(float delay)
    {
        yield return new WaitForSeconds(delay);
        isCActive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!isCActive)
            return;
        Debug.Log("You ded");
    }
}