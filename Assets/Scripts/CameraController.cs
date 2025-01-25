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
        [SerializeField]
        float zoomSpeed = 5.0f;
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
            transform.position = new Vector3(midPoint.x, midPoint.y, -10);
        }
    }
}
