using System;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float speed = 5.0f;
        [SerializeField] private InputSystem inputSystem;

        public void Awake()
        {
            if (inputSystem)
            {
                throw new Exception("Input system not assigned");
            }
        }

        public void Move()
        {
            // Get values from unity input systwm
            var input = inputSystem.getMovement();
            input *= speed * Time.deltaTime;
            transform.Translate(new Vector3(input.x, input.y, 0));
        }
    }
}