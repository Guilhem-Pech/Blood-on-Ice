using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[ExecuteAlways]
public class SpotlightPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float smoothTime = 0.1F;
    [SerializeField] [NotNull] private GameObject projectorLightRuntime;
    [SerializeField]
    private Vector3 projectorOffset = Vector3.zero;
    [SerializeField]
    private Vector2 _projectorVelocity = Vector2.zero;

    private void Start()
    {
        Vector3 position = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 position = transform.position;
        projectorLightRuntime.transform.position = Vector2.SmoothDamp(projectorLightRuntime.transform.position, position + projectorOffset, ref _projectorVelocity, smoothTime);
    }

    private void OnDestroy()
    {
//        Destroy(projectorLightRuntime);
    }
}
