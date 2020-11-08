using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] spawners;
    public float moveSpeed;

    TimeManager tm;

    private void Awake()
    {
        EventManager.killPlayer += OnPlayerDeath;
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
        GameObject box;
        while (true)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                int rand = Random.Range(0, obstacles.Length);
                box = Instantiate(obstacles[rand], new Vector3(obstacles[rand].transform.position.x, obstacles[rand].transform.position.y, spawners[i].transform.position.z), Quaternion.identity);
                StartBoxMovement(box.transform.childCount, box);
            }
            yield return new WaitForSeconds(4.5f);
        }
    }

    private void StartBoxMovement(int numOfChildren, GameObject box)
    {
        if (numOfChildren > 0)
            for (int i = 0; i < numOfChildren; i++)
                box.GetComponentsInChildren<Rigidbody>()[i].velocity = Vector3.back * moveSpeed;
        else
            box.GetComponent<Rigidbody>().velocity = Vector3.back * moveSpeed;
    }

    private void OnPlayerDeath()
    {
        StopSpawn();
    }

    private void OnDestroy()
    {
        EventManager.killPlayer -= OnPlayerDeath;
    }
}
