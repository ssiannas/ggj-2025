using UnityEngine;

namespace ggj_2025
{
    public class ObstacleController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        // Update is called once per frame
        void Update()
        {
            _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
