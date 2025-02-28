using UnityEngine;

namespace DefaultNamespace
{
    public class groundCheck : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other) 
        {
            if (other.otherRigidbody.CompareTag("Player"))
            {
                Movement.instance.isJumping = false;
            }
        }

        void OnCollisionExit2D(Collision2D other)
        {
            if (other.otherRigidbody.CompareTag("Player"))
            {
                Movement.instance.isJumping = true;
            }
        }
    }
}