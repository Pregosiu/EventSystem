using UnityEngine;

namespace Enemies
{
    public class Cannonball : MonoBehaviour {

        [SerializeField] private int _speed;

        void Start() {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector3 cannonballVector = transform.right * _speed;
            rb.velocity = cannonballVector;
        }

        private void OnBecameInvisible() {
            Destroy(gameObject, 2);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                return;
            }

            Destroy(collision.gameObject);
        }
    }
}
