using System.Collections;
using UnityEngine;

namespace Enemies
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _cannonball;
        [SerializeField] private float _stopTime;
        private bool _isActive;
        private Coroutine _shootCoroutine;
        private Coroutine _followCoroutine;
        private bool _isShooting;




        void Start()
        {
 
            GameEvents.OnPlayerEnter += Enable;
            _isActive = false;
            _isShooting = false;
        }

        private void Update()
        {
            if(_isActive != true)
            {
                return;
            }

        }


        private void Stop(bool isShooting)
        {
            _isShooting = true;
        }

        private void Enable(bool isActive)
        {
            if(isActive == true)
            {
                _followCoroutine = StartCoroutine(Follow());
            }
            else if(isActive == false)
            {
                StopCoroutine(_followCoroutine);
                CancelInvoke("Shoot");
            }

            _isActive = isActive;
        }


        private void Shoot()
        {
            Instantiate(_cannonball, transform.position, transform.rotation);
            _isShooting = true;
            
        }

        private IEnumerator Follow()
        {
            InvokeRepeating("Shoot", 0, 2);
            while (true) {
            // Vector directed from the cannon to the targer object
            Vector3 direction = (_target.position - transform.position).normalized;

            // Transformations necessary for correct rotation in 2D
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);

            // Rotate to the target rotation at the set speed until the expected rotation value is reached
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);

                if (_isShooting == true)
                {
                    yield return new WaitForSeconds(_stopTime);
                    _isShooting = false;

                }

                yield return null;

            }
        }






    }
}