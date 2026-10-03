using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private TextMeshProUGUI healthText;
    private CharacterController characterController;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        ResetPlayer();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"{currentHealth}";
        }
    }

    private void Die()
    {
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        characterController.enabled = false;
        transform.position = new Vector3(0.0f,5f,0f);
        characterController.enabled = true;
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
}
