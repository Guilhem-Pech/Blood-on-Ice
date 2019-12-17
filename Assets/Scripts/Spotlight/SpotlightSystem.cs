using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Spotlight
{
    [ExecuteAlways]
    public class SpotlightSystem : MonoBehaviour
    {
        
        [SerializeField] private Light2D baseSpot;
        [SerializeField] private Light2D spotTrace;
        [SerializeField][Range(0,1)]private float smooth = 0;
        private Vector2 _posBase = Vector2.zero;

        private Transform _baseSpotTransform;
        private Transform _spotTraceTransform;

        private void Start()
        {
            _baseSpotTransform = baseSpot.transform;
            _spotTraceTransform = spotTrace.transform;
        }

        public void SetLightBasePos(Vector2 vector2)
        {
            _posBase = vector2;
        }

        public Vector2 GetPostition()
        {
            return _posBase;
        }
        
        private void FixedUpdate()
        {
            _baseSpotTransform.SetPositionAndRotation(_posBase,Quaternion.identity);
        }

        private void Update()
        {
            Vector3 dir = _baseSpotTransform.position - _spotTraceTransform.position;
            float angle = - Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            _spotTraceTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            float distance = Vector2.Distance(_spotTraceTransform.position, _baseSpotTransform.position);
            spotTrace.pointLightOuterRadius = distance;
            spotTrace.pointLightOuterAngle = Mathf.Tan(baseSpot.pointLightOuterRadius * 2 / distance) * Mathf.Rad2Deg;
            spotTrace.pointLightInnerAngle = spotTrace.pointLightOuterAngle * smooth;
            baseSpot.pointLightInnerRadius = baseSpot.pointLightOuterRadius * smooth;
        }
    }
}
