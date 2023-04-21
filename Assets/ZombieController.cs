using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class ZombieController : MonoBehaviour
{
    Transform player;
    NavMeshAgent agent;
    float hp;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        bool seesPlayer = false;
        bool hearsPlayer = false;
        
        RaycastHit hit;
        Vector3 playerVector = player.position - transform.position;
        Debug.DrawRay(transform.position, playerVector, Color.yellow);
        if (Physics.Raycast(transform.position, playerVector, out hit))
        {
            Debug.Log("widzê:" + hit.transform.name);
        }
            
        
        
        //transform.LookAt(player.position);
        //transform.Translate(Vector3.forward * Time.deltaTime);
        if(hit.collider.gameObject.CompareTag("Player"))
        seesPlayer= true;

        Collider[] nearby = Physics.OverlapSphere(transform.position, 5f);
        foreach(Collider collider in nearby)
        {
            if (collider.transform.CompareTag("Player"))
            {
                hearsPlayer = true;
            }    
        }

        if(seesPlayer || hearsPlayer)
        {
            agent.destination = player.position;
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
        }
    }

    public void ReceiveDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
            Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
