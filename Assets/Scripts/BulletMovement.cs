using UnityEngine;

namespace ggj_2025
{
    public class BulletMovement : MonoBehaviour
    {
        public Vector2 direction;
        public float speed;
        public float damage = 5f;
        public float size = 10f;
        public int PlayerIndex = 0;
        
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField] private CameraChannel cameraChannel;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        // Set the movement direction and speed
        public void SetMovement(Vector2 moveDirection, float moveSpeed)
        {
            direction = moveDirection.normalized; // Normalize direction to ensure consistent movement
            speed = moveSpeed;
            _rigidbody2D.AddForce(direction * speed);
        }

        private void Start()
        {
            //transform.localScale *= size;
            transform.localScale = new Vector3(transform.localScale.x * size, transform.localScale.y * size, transform.localScale.z * size);
        }
        void Update()
        {
            // Move the object in the specified direction
            var factor = Time.deltaTime * speed;
            _spriteRenderer.sortingOrder =  Mathf.RoundToInt(transform.position.y * 100) * -1;
            //TO DO: RIGID BOODY  
        }


        void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Bubble"))
            {
                Destroy(gameObject);
                if (collision.gameObject.CompareTag("P1") || collision.gameObject.CompareTag("P2"))
                {
                    PlayerController target = collision.gameObject.GetComponent<PlayerController>();
                    cameraChannel.CameraShake(0.15f, 0.05f);
                    target.TakeDamage(damage);
                }
            }

        }

    }
}