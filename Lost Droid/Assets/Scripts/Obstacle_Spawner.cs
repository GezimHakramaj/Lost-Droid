using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle_Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float moveSpeed;

    private void Awake()
    {
        Kill_Player.killPlayer += OnPlayerDeath;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn(); 
    }

    public void StartSpawn()
    {
        StartCoroutine(ObstacleSpawn()); 
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            // Stops all objects on player death.
            obstacle.GetComponent<Rigidbody>().velocity = Vector3.back * 0;
        }
    }

    IEnumerator ObstacleSpawn()
    {
        while (true)
        {
            // Spawn a random obstacle in the obstacles array
            int rand = Random.Range(0, obstacles.Length);
            // Spawn that box with the box prefab's position (x,y) but with the box spawner's z
            GameObject box = Instantiate(obstacles[rand], new Vector3(obstacles[rand].transform.position.x, obstacles[rand].transform.position.y, transform.position.z), Quaternion.identity);
            if (box.transform.childCount > 0) // Check if obj is a combination of object.
                for (int i = 0; i < box.transform.childCount; i++)
                    // Move the box children of empty game obj parent back on Z axis * moveSpeed
                    box.GetComponentsInChildren<Rigidbody>()[i].velocity = Vector3.back * moveSpeed;
            else
                // Move the box back on Z axis * moveSpeed
                box.GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;       
            // Wait 3 seconds before spawning again.
            yield return new WaitForSeconds(4.5f);
        }
    }
    private void OnPlayerDeath()
    {
        StopSpawn();
    }

    private void OnDestroy()
    {
        Kill_Player.killPlayer -= OnPlayerDeath;
    }
}
