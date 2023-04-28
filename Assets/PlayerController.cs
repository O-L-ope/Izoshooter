using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float hp = 10;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public float playerSpeed = 2;
    Vector2 movementVector;
    Transform bulletSpawn;
    public GameObject hpBar;
    Scrollbar hpScrollBar;
    NavMeshAgent agent;

    
    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
        hpScrollBar = hpBar.GetComponent<Scrollbar>();
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //obrót wokó³ osi Y o iloœæ stopni równ¹ wartosci osi X kontrolera
        // transform.Rotate(Vector3.up * movementVector.x);
        //przesuniêcie do przodu (transform.forward) o wychylenie osi Y kontrolera w czasie jednej klatki
        // transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime * playerSpeed);


        Vector3 rotation = new Vector3(0, movementVector.x, 0);
        transform.Rotate(rotation);
        if (movementVector.y > 0)
        {
            agent.destination = transform.position + transform.forward;
            agent.isStopped = false;
        }
        if (movementVector.y == 0)
        {
            agent.isStopped = true;
        }
            
    }
    
    void OnMove(InputValue inputValue) 
    {
        movementVector = inputValue.Get<Vector2>();

        //Debug.Log(movementVector.ToString());
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
   
            hp--;
            if(hp <= 0) Die();
            hpScrollBar.size = hp / 10;
            Vector3 pushVector = other.gameObject.transform.position - transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized*5, ForceMode.Impulse);
        }
        if(other.gameObject.CompareTag("Heal"))
        {
            hp = 10;
            hpScrollBar.size = hp / 10;
            Destroy(other.gameObject);
        }
    }
    void Die()
    {
        Application.Quit();
        GetComponent<BoxCollider>().enabled = false;
        transform.Translate(Vector3.up);
        transform.Rotate(Vector3.right * -90);
        
        //Time.timeScale = 0;
    }

}
