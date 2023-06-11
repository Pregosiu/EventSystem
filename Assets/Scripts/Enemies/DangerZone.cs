using UnityEngine;

namespace Enemies
{
    public class DangerZone : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameEvents.PlayerEnter(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameEvents.PlayerEnter(false);
            }
        }

    }
}