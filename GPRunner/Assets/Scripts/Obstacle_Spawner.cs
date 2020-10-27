using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle_Spawner: MonoBehaviour
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
        StartCoroutine(boxSpawn());
    }

    public void StopSpawn()
    {
        StopCoroutine(boxSpawn());
        // Deletes all obstacles when game ends.
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            obstacle.GetComponent<Rigidbody>().velocity = Vector3.left * 0;
        }
    }

    IEnumerator boxSpawn()
    {
        while (true)
        {
            // Spawn a random obstacle in the obstacles array
            int rand = Random.Range(0, obstacles.Length);
            // Spawn that box with the box prefab's position (x,y) but with the box spawner's z
            GameObject box = Instantiate(obstacles[rand], new Vector3(obstacles[rand].transform.position.x, obstacles[rand].transform.position.y, transform.position.z), Quaternion.identity);
            // Move the box back on Z axis * moveSpeed
            box.GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;
            
            // Wait 3 seconds before spawning again.
            yield return new WaitForSeconds(3);
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
