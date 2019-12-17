using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Spotlight;
using UnityEngine;
public class SpotlightPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float smoothTime = 0.1F;
    [SerializeField] [NotNull] private SpotlightSystem spotlightSystem;
    [SerializeField]
    private Vector3 projectorOffset = Vector3.zero;
    private Vector2 _projectorVelocity = Vector2.zero;

    private void Start()
    {
        Vector3 position = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(!spotlightSystem) return;
        Vector3 position = transform.position;
        spotlightSystem.SetLightBasePos(Vector2.SmoothDamp(spotlightSystem.GetPostition(),
            position + projectorOffset, ref _projectorVelocity, smoothTime));
    }

    public GameObject GetProjectorRuntime()
    {
        return spotlightSystem.gameObject;
    }
    private void OnDisable()
    {
        if(spotlightSystem != null)
            spotlightSystem.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if(spotlightSystem != null)
            spotlightSystem.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        if(spotlightSystem != null)
            Destroy(spotlightSystem.gameObject);
    }

    public void SetProjectorRuntime(SpotlightSystem projector)
    {
        spotlightSystem = projector;
    }
}
