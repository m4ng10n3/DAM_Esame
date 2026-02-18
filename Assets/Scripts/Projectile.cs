
    using UnityEngine;

    public class Projectile : MonoBehaviour
    {
        [Header("Settings")]
        public float speed = 3f;
        
        private void Update()
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > 10)
            {
                Destroy(gameObject);
            }
        }
    }
