using Constants;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private int _jumpForce;
        private Rigidbody2D _rb;
        private bool _isGrounded;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            float xDisplacement = Input.GetAxis(AxisConsts.HORIZONTAL);
            _rb.velocity = new Vector2(xDisplacement * _speed, _rb.velocity.y);
            
            GameEvents.PlayerMovement(_rb.velocity.x);
        }

        private void Jump()
        {
            if (Input.GetButtonDown(AxisConsts.JUMP) && _isGrounded)
            {
                _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(TagConsts.GROUND))
            {
                return;
            }
            
            _isGrounded = true;
            GameEvents.PlayerJump(false);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(TagConsts.GROUND))
            {
                return;
            }
            
            _isGrounded = false;
            GameEvents.PlayerJump(true);
        }
    }
}