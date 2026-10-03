using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private bool isUsed = false;

    void OnTriggerEnter(Collider other)
    {
        if  (other.CompareTag("Player") && !isUsed)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();

            player.setSpeed(2);
            isUsed = true;
        }
    }
}
