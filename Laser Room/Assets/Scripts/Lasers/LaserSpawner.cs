using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] laserPrefabs;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private float initialDelay = 1f;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    
    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            if (laserPrefabs != null && laserPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, laserPrefabs.Length);
                GameObject selectedLaser = laserPrefabs[randomIndex];

                if (selectedLaser != null)
                {
                    Instantiate(selectedLaser, transform.position, transform.rotation);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
