using System;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerShootingController : MonoBehaviour
    {
        private float bulletSpeed = 5f;
        [SerializeField] private GameObject projectilePrefab;
        private float _firerate = 1f;
        private float _cooldownTimestamp;
        private float _fireCooldown;
        public float Firerate
        {
            get => _firerate; 
            private set
            {
                _firerate = value;
                _fireCooldown = 1 / value;
            }
        }

        private void Awake()
        {
            _fireCooldown = 1 / _firerate;
            if (projectilePrefab is null)
            {
                throw new ArgumentNullException(nameof(projectilePrefab));
            }
        }
        
        public void TryShoot(Vector2 direction)
        {
            if (Time.time < _cooldownTimestamp) return;
            _cooldownTimestamp = Time.time + _fireCooldown;
            // Shoot!
            Shoot(direction);
        }

        public void ShootMultiple(Vector2[] directions)
        {
            foreach (var direction in directions)
            {
                Shoot(direction);
            }
        }

        private void Shoot(Vector2 direction)
        {
            // Calculate the new spawn position
            Vector2 position = transform.transform.position;

            // Instantiate the prefab
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Add a script to make the prefab move
            var moveScript = projectile.GetComponent<BulletMovement>();
            moveScript.SetMovement(direction, bulletSpeed);
        }
    }
}