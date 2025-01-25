using System;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float speed = 5.0f;
        private Camera _mainCamera;
        public void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            // have our z coordinate be equal to our y coordinate
        }

        public void Move(InputSystem inputSystem)
        {
            var input = inputSystem.GetMovement();
            input *= speed * Time.deltaTime;
            transform.Translate(new Vector3(input.x, input.y, 0));
        }
    }
}