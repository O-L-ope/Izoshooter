using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieController : MonoBehaviour
{
    Transform player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
        transform.Translate(Vector3.forward * Time.deltaTime);
        
    }
}
