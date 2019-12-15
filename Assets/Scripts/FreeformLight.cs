using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace DefaultNamespace
{
    public class FreeformLight : MonoBehaviour
    {
        private Light2D _light2D;
        
        [SerializeField]
        private Transform anchor1;
        [SerializeField]
        private Transform anchor2; 
            
        private Vector3[] shape;

        private void Start()
        {
            _light2D = GetComponent<Light2D>();
            anchor1 = GameManager.GetInstance().spotLightAnchor1;
            anchor2 = GameManager.GetInstance().spotLightAnchor2;
        }

        private void OnEnable()
        {
            try
            {
                AkSoundEngine.PostEvent("Spotlight_on", gameObject);
            }
            catch
            {
                // ignored
            }
        }

        private void Update()
        {
            shape = _light2D.shapePath;
            shape[6] = transform.InverseTransformPoint(anchor1.position);
            shape[7] = transform.InverseTransformPoint(anchor2.position);
        }
    }
}