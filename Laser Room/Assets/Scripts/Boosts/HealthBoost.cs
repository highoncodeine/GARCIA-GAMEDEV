using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    private bool isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUsed)
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            player.Heal(20);
            isUsed = true;
        }
    }
}
