using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidManager : MonoBehaviour
{
    public GameObject[] asteroids;
    public GameObject[] aSpawners;

    

    
    

    

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

        StartCoroutine(AsteroidSpawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject asteroid in asteroids)
        {
            // Stops all objects on player death.
            asteroid.GetComponent<Rigidbody>().velocity = Vector3.back * 0;
        }
    }

    IEnumerator AsteroidSpawn()
    {
        GameObject aBox;
        float randSpawn = Random.Range(250.0f, 450.0f);
        while (true)
        {
            
            for (int i = 0; i < aSpawners.Length; i++)
            {
                int rand = Random.Range(0, asteroids.Length);
                aBox = Instantiate(asteroids[rand], new Vector3(aSpawners[i].transform.position.x, aSpawners[i].transform.position.y, randSpawn), Quaternion.identity);


                StartBoxMovement(aBox.transform.childCount, aBox);
            }
            yield return new WaitForSeconds(3.5f);
        }
    }

    private void StartBoxMovement(int numOfChildren, GameObject aBox)
    {
         float speedModifier = Random.Range(20.0f, 30.0f);
        if (numOfChildren > 0)
            for (int i = 0; i < numOfChildren; i++)
                aBox.GetComponentsInChildren<Rigidbody>()[i].velocity = Vector3.back * (aBox.transform.position.z + speedModifier);
        else
            aBox.GetComponent<Rigidbody>().velocity = Vector3.back * (aBox.transform.position.z + speedModifier);
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
