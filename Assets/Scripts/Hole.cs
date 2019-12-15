using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.U2D;
using UnityEngine.U2D;

public class Hole : MonoBehaviour
{
    public float destructionTime = 5f;
    public float delayActivation = 1f;
    private bool _isCActive = false;
    private SpriteShapeController _spriteShape;
    public IList<Vector3> vertexPos;
    private Collider2D _collider2D;
    public GameObject vortexPrefab;
    private GameObject _vortex;
   
    private void Start()
    {
        Vector3 pos = AvgVector(vertexPos);
        pos.z = 5;
        _vortex = Instantiate(vortexPrefab, pos, vortexPrefab.transform.rotation);
        GameManager.GetInstance().OnEndingRoundEvent().AddListener(OnEndRound);
        _spriteShape = GetComponent<SpriteShapeController>();
        Destroy(gameObject,destructionTime);
        StartCoroutine(StartTrigger(delayActivation));
    }

    private void OnEndRound()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
    
    private IEnumerator StartTrigger(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isCActive = true;
    }

    private void OnDestroy()
    { GameManager.GetInstance().OnEndingRoundEvent().RemoveListener(OnEndRound);
       Destroy(_vortex);
       AkSoundEngine.PostEvent("Geyser_Stop", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(!_isCActive)
            return; 
        
        
        
       Rigidbody2D rigidbody2Body = other.gameObject.GetComponentInParent<Rigidbody2D>();
       StartCoroutine(RepulsePlayer(rigidbody2Body, rigidbody2Body.velocity * -0.7f));
       
       //rigidbody2Body.AddForce(rigidbody2Body.velocity * -1.5f,ForceMode2D.Impulse);
    }


    private IEnumerator RepulsePlayer(Rigidbody2D rigidbody2D, Vector2 force)
    {
        int cpt = 3;
        
        for (;cpt >= 0;--cpt)
        {
            rigidbody2D.AddForce(force,ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.1f);
        }
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