using UnityEngine;
using UnityEngine.InputSystem;

public class BallShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootForce = 1500f;
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private float ballLifetime = 5f;

    private InputAction attackInput;
    private float nextFireTime = 0f;

    private void Start()
    {   
        attackInput = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        if (attackInput != null && attackInput.IsPressed() && Time.time >= nextFireTime)
        {
            ShootBall();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void ShootBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);
        
        if (ball.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(spawnPoint.forward * shootForce);
        }
        
        Destroy(ball, ballLifetime);
    }
}
