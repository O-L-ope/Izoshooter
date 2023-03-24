using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    public GameObject zombiePrefab;
    public static int enemies;
    public int maximumEnemies;

    // Start is called before the first frame update
    void Start()
    {
        maximumEnemies = 3;
    }

    // Update is called once per frame
    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length < maximumEnemies)
        {
            var enemiesNeeded = maximumEnemies - enemies.Length;
            for(int i = 0;i < enemiesNeeded; i++)
            {
                Vector3 spawnPosition = GetRandomSpawn();
                GameObject zombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);
            }
            
        }
        
    }

    Vector3 GetRandomSpawn()
    {
        Vector3 position;
        do
        {
            position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
            position = position.normalized * Random.Range(10, 20);
        }
        while (!Physics.CheckSphere(position, 20));
        return position;
    
    }
}
