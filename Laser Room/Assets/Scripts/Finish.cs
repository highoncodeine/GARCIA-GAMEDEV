using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.text = "You Win!";
        }
    }
}
