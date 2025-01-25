using System.Collections;
using UnityEngine;

namespace ggj_2025
{
    public class CameraController : MonoBehaviour
    {
        public GameObject player1;
        public GameObject player2;

        private Camera _camera;
        private float _maxDistance;
        private float _originalZoom;
        bool _isShaking = false;
        
        [SerializeField] private CameraChannel cameraChannel;
        [SerializeField]
        float zoomSpeed = 5.0f;

        private float _shakeMagnitude;
        private float _shakeDuration;
        private float _elapsedShakeDuration;
        
        private Vector3 _originalPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            _camera = Camera.main;
            if (_camera is null)
            {
                throw new System.Exception("Main camera not found");
            }
            _maxDistance = GetDistance();
            _originalZoom = _camera.orthographicSize; 
            _camera.orthographic = false;
            cameraChannel.OnCameraShake += StartCameraShake;
            _originalPosition = transform.position;
        }

        private float GetDistance()
        {
            return Vector2.Distance(player1.transform.position, player2.transform.position);
        }
        
        // Update is called once per frame
        private void Update()
        {
            var distance = GetDistance();
            var midPoint =  (player1.transform.position + player2.transform.position) / 2;
            
            var zoomFactor = distance / _maxDistance;
            var targetFov = Mathf.Lerp(20, 60f, zoomFactor);
            _camera.fieldOfView = targetFov;
            var targetPosition = new Vector3(midPoint.x, midPoint.y, -10);
            _camera.transform.position = targetPosition;
            _originalPosition = targetPosition;
            if (_isShaking)
            {
                Shake();
            }
        }

        private void Shake()
        {
            if (_elapsedShakeDuration < _shakeDuration)
            {
                // Calculate random displacement on the unit circle
                Vector2 shakeOffset = Random.insideUnitCircle * _shakeMagnitude;

                // Apply the shake offset to the camera position
                transform.position = _originalPosition + new Vector3(shakeOffset.x, shakeOffset.y, 0);

                // Increment elapsed duration
                _elapsedShakeDuration += Time.deltaTime;
            }
            else
            {
                // Reset shake parameters
                _isShaking = false;
                _elapsedShakeDuration = 0f;
                transform.position = _originalPosition;
            }
        }
        void StartCameraShake(float shakeDuration, float shakeMagnitude)
        {
            _shakeMagnitude = shakeMagnitude;
            _shakeDuration = shakeDuration;
            _isShaking = true;
            _elapsedShakeDuration = 0f;
        }
    }
}
