using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_spawner : MonoBehaviour
{
    public GameObject doubleBoxPrefab;
    private Vector3 spawns;
    public float moveSpeed;
    public float spawnDelay;

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
    }

    IEnumerator boxSpawn()
    {

        while (true)
        {
            GameObject box = Instantiate(doubleBoxPrefab, transform.position, Quaternion.identity);
            box.GetComponent<Rigidbody2D>().velocity = Vector2.up * 30;

           
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
