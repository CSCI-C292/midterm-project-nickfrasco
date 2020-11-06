using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject foodPrefab2;
    public GameObject foodPrefab3;
    public GameObject foodPrefab4;
    
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public GameObject[] FoodPrefabs;
    public float spawnRate = 2.0f;
    private float nextSpawn = 0.0f;
    
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
    }

    void Update()
    {

     }
        
    void Spawn(){

        int x = (int)Random.Range(borderRight.position.x,borderLeft.position.y);
        int y = (int)Random.Range(borderBottom.position.x,borderTop.position.y);
        
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + spawnRate;
            GameObject piClone = Instantiate(FoodPrefabs[Random.Range(0, FoodPrefabs.Length)], new Vector2(x,y),Quaternion.identity) as GameObject;
        }
    }
}
