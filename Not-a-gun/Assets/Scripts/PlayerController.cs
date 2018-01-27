using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = new Vector3(0,0,0);
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            moveDirection = Vector3.Normalize(x * transform.right + z * transform.forward);
            moveDirection *= 100;
            // if (Input.GetButton("Jump"))
            //     moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y += UnityEngine.Physics.gravity.y * Time.deltaTime;
        controller.SimpleMove(moveDirection * Time.deltaTime);

        //rb.AddForce(new Vector3(x, 0, z), ForceMode.Acceleration);
        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
    }
}
