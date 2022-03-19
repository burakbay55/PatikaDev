using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
   private Rigidbody ballRigidbody;
   public float speed = 2;
   public Vector3 jumpSpeed = new Vector3(0,2,0);
   private bool isGrounded = false;

   void Start()
   {
       ballRigidbody = GetComponent<Rigidbody>();
   }

   void FixedUpdate()
   {
       float movementHorizontal = Input.GetAxis("Horizontal");
       float movementVertical = Input.GetAxis("Vertical");

       if(Input.GetButton("Jump") && isGrounded == true)
       {
           ballRigidbody.AddForce(jumpSpeed*transform.position.y);
       }

       Vector3 movement = new Vector3(movementHorizontal,0,movementVertical);

       ballRigidbody.AddForce(movement*speed);
   }
    
   void OnCollisionEnter(Collision col)
   {
       if(col.collider.CompareTag("plane"))
       {
           Destroy(this.gameObject,1f);
       }
   }
   void OnCollisionStay(Collision col)
   {
     isGrounded = true;
   }
   void OnCollisionExit(Collision col)
   {
     isGrounded = false;
   }
   
}
