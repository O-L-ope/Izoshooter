using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 inputVector;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log("Wychylenie kontrolera: " + inputVector.ToString());


        //transform.Translate(movement);
     // Vector3 movement = transform.forward * inputVector.y;
     // rb.AddForce(movement, ForceMode.VelocityChange);
     // Vector3 rotation = new Vector3(0, inputVector.x, 0);
        //transform.Rotate(rotation);
    //  Vector3 rotation = transform.up * inputVector.x;
    //  rb.AddTorque(rotation, ForceMode.VelocityChange);

    }
    private void FixedUpdate()
    {

        if (inputVector.y == 0)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector3 movement = transform.forward * inputVector.y;
            rb.AddForce(movement, ForceMode.VelocityChange);
        }

        if(inputVector.x == 0)
        {
            rb.angularVelocity = Vector3.zero; 
        }
        else
        {
            Vector3 rotation = transform.up * inputVector.x;
            rb.AddTorque(rotation , ForceMode.VelocityChange);
        }
        
        //transform.Translate(movement);
    //  Vector3 movement = transform.forward * inputVector.y;
    //  rb.AddForce(movement, ForceMode.VelocityChange);
        // Vector3 rotation = new Vector3(0, inputVector.x, 0);
        //transform.Rotate(rotation);
    //  Vector3 rotation = transform.up * inputVector.x;
   //   rb.AddTorque(rotation, ForceMode.VelocityChange);
    }
    void OnMove(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();
        
    }
}
