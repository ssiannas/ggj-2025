using System;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float speed = 3.0f;
        private Camera _mainCamera;
        
        private Vector2 _direction;
        public Vector2 Direction
        {
            get => _direction;
            set => _direction = value * speed * Time.deltaTime;
        }

        public void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void Move()
        {
            transform.Translate(new Vector3(Direction.x, Direction.y, 0));
        }
        
    }
}