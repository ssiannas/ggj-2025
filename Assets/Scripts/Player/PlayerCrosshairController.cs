using System;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerCrosshairController : MonoBehaviour
    {
        [SerializeField] private float crosshairDistance = 1f;
        [SerializeField] private GameObject crosshair;
        
        private Camera _mainCamera;
        public void Awake()
        {
            if (crosshair is null)
            {
                throw new Exception("Crosshair not assigned");
            }
            _mainCamera = Camera.main;
            
            // Instantiate crosshair to the player + crosshairDistance
            crosshair = Instantiate(crosshair, transform.position + new Vector3(0, crosshairDistance, 0), Quaternion.identity);
        }
        
        /**
         * Updates the crosshair position based on the aim input.
         *
         * @param inputSystem The input system to get the aim input from.
         * @return The aim input.
         */
        public void UpdateCrosshair(Vector2 aim)
        {
            if (aim == Vector2.zero)
            {
                return;
            }
            crosshair.transform.position = transform.position + new Vector3(aim.x, aim.y, 0) * crosshairDistance;
        }
    }
}
