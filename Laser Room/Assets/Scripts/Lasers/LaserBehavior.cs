using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   
   void Update()
   {
      transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Despawn"))
      {
         Destroy(gameObject);
      }
   }
}
