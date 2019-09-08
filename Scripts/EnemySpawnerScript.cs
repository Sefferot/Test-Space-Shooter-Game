using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public float minX = -5.44f, maxX = 5.44f;

    public GameObject[] asteroidPrefab;
    public GameObject enemyPrefab;

    public float timer = 2f;

    void Start()
    {
        Invoke("SpawnEnemy", timer);
    }

   
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float posX = Random.Range(minX, maxX);
        Vector2 temp = transform.position;
        temp.x = posX;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 180f));
        }

        Invoke("SpawnEnemy", timer);
    }

   










}//class
