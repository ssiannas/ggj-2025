using System;
using NUnit.Framework;
using UnityEngine;

namespace ggj_2025
{
    public class PlayerShootingController : MonoBehaviour
    {
        private float bulletSpeed = 5f;
        [SerializeField] private GameObject projectilePrefab;
        private float _firerate = 1.5f;
        private float _cooldownTimestamp;
        private float _fireCooldown;
        private float _offset= 1.2f;
        public bool IsShooting { get; set; }
        [SerializeField] private AudioChannel audioChannel;

        private string[] shootingSounds =
        {
            "shoot_high_pitch",
            "shoot_low_pitch",
            "shoot_medium_pitch"
        };
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
            if (Time.time < _cooldownTimestamp)
            {
                return;
            };
            _cooldownTimestamp = Time.time + _fireCooldown;
            // Shoot!
            // Get random shooting sound 
            var soundName = shootingSounds[UnityEngine.Random.Range(0, shootingSounds.Length)];
            audioChannel.PlayAudio(soundName);
            Shoot(direction);
        }
        
        public void StopShoot()
        {
            IsShooting = false;
        }

        public void StartShoot()
        {
            IsShooting = true;
        }

        public void ShootMultiple(Vector2[] directions)
        {
            audioChannel.PlayAudio("special");
            foreach (var direction in directions)
            {
                Shoot(direction);
            }
        }

        private void Shoot(Vector2 direction)
        {

            // Instantiate the prefab
            var projectile = Instantiate(projectilePrefab, transform.position + (Vector3)(direction.normalized*_offset), Quaternion.identity);

            // Add a script to make the prefab move
            var moveScript = projectile.GetComponent<BulletMovement>();
            moveScript.SetMovement(direction, bulletSpeed);
        }
    }
}
