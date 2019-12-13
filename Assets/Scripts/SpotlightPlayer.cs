using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class SpotlightPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float smoothTime = 0.1F;
    [SerializeField]
    private GameObject projectorLight;
    [SerializeField]
    private Vector3 projectorOffset = Vector3.zero;
    [SerializeField]
    private Vector2 _projectorVelocity = Vector2.zero;

    private void Start()
    {
        Vector3 position = transform.position;
        projectorLight = Instantiate(projectorLight, position, Quaternion.identity);   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        projectorLight.transform.position = Vector2.SmoothDamp(projectorLight.transform.position, position + projectorOffset, ref _projectorVelocity, smoothTime);
    }

    private void OnDestroy()
    {
        Destroy(projectorLight);
    }
}
