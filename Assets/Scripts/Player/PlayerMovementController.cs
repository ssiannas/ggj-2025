using System;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float speed = 5.0f;
        [SerializeField] private InputSystem inputSystem;
        private Camera _mainCamera;
        public void Awake()
        {
            if (inputSystem is null)
            {
                throw new Exception("Input system not assigned");
            }
            _mainCamera = Camera.main;
        }

        public void Move()
        {
            var input = inputSystem.GetMovement();
            input *= speed * Time.deltaTime;
            transform.Translate(new Vector3(input.x, input.y, 0));
        }
    }
}