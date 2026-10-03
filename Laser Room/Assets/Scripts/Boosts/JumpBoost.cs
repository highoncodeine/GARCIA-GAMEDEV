using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private bool isUsed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isUsed == false)
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.setJump(2);
                isUsed = true;
            }
        }
    }
}
