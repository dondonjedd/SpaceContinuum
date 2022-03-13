using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidsPrefabs;
    [SerializeField] private float asteroidSpawnDuration = 1.5f;
    [SerializeField] private Vector2 forceRange;

    private float timer;

    private Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            spawnAsteroid();
            timer += asteroidSpawnDuration;
        }
    }
    private void spawnAsteroid() {

        int side = Random.Range(0, 4);
        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0://left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                //right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                //top
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
            case 3:
                //bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            default:
                break;
        }

            GameObject selectedAsteroid = asteroidsPrefabs[Random.Range(0, asteroidsPrefabs.Length)];
            Vector3 worldSpawnPoint= mainCamera.ViewportToWorldPoint(spawnPoint);
            worldSpawnPoint.z = 0f;

            GameObject spawnedAsteroid = Instantiate(selectedAsteroid, worldSpawnPoint, Quaternion.Euler(0f,0f,Random.Range(0f, 360f)));

            Rigidbody rb = spawnedAsteroid.GetComponent<Rigidbody>();
            rb.velocity = direction.normalized * Random.Range(forceRange.x,forceRange.y);


        
    
    
    }
}
