using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] EnemiesPrefab;            // Array of enemy prefabs to spawn
    [SerializeField] float secondSpawn = 0.5f;             // Time interval between enemy spawns
    [SerializeField] float minTras;                       // Minimum spawn position
    [SerializeField] float maxTras;                      // Maximum spawn position
    public Timer timer;                                 // Reference to the Timer script

    void Start()                                        // Start spawning enemies
    {
        StartCoroutine(EnemySpawn());
    }

  

    IEnumerator EnemySpawn()                         // Coroutine for spawning enemies
    {
        while (true)
        {

                                                    
            if (timer != null && timer.IsTimeUp())       // Check if time is up before spawning enemies
            {
                yield break;                            // Exit the coroutine to stop spawning enemies
            }


            var wanted = Random.Range(minTras, maxTras);                // Generate random spawn position
            var position = new Vector3(wanted, transform.position.y);   

            GameObject obstacle = Instantiate(EnemiesPrefab[Random.Range(0, EnemiesPrefab.Length)], position, Quaternion.identity);     // Instantiate a random enemy prefab at the generated position


            
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();          // Apply the current gravity scale to the spawned enemy
            if (rb != null)
            {
                rb.gravityScale = GravityManager.instance.GetCurrentGravityScale();
                Debug.Log("Spawned enemy with gravity scale: " + rb.gravityScale);
            }


            yield return new WaitForSeconds(secondSpawn);               // Wait for the specified time interval before spawning the next enemy
            Destroy(obstacle, 5f);                                     // Destroy the spawned enemy after 5 seconds
        }
    }

  
}