using UnityEngine;

public class StopMoving : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            transform.SetParent(null); 
            
            rb.isKinematic = false; 
            
            rb.AddForce(collision.relativeVelocity * 0.5f, ForceMode.Impulse);
            
            this.enabled = false;
        }
    }
}
