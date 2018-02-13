using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 3f;
    float mDelta = 10f; 
    Vector3 movement;
    Rigidbody playerRigidbody;
    private int floorMask;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
    }

       void FixedUpdate(){
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Move(h, v);
        }

        void Move (float h, float v){
            movement.Set (h, 0f, v);
            movement = movement.normalized * speed * Time.deltaTime;
            playerRigidbody.MovePosition (transform.position + movement);
        }



    //camera movement
void Update()
    {
        
        if (Input.mousePosition.x >= Screen.width - mDelta)
        {
            transform.rotation = transform.rotation *
                Quaternion.Euler(0, 1, 0);
        }
        if (Input.mousePosition.x <= 0 + mDelta)
        {
            transform.rotation = transform.rotation *
                Quaternion.Euler(0, -1, 0);
        }
//        if (Input.mousePosition.y >= Screen.height - mDelta)
//        {
//            transform.rotation = transform.rotation *
//                Quaternion.Euler(-1, 0, 0);
//        }
//        if (Input.mousePosition.y <= 0 + mDelta)
//        {
//            transform.rotation = transform.rotation *
//                Quaternion.Euler(1, 0, 0);
//        }
    }
	
}
