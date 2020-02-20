﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float speed=5f;
    public bool onCircle=false;
    public bool onPlanet=false;
    // public bool
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool rightInput;
        bool leftInput;

        /*rightInput = Input.GetKey(KeyCode.RightArrow);
        leftInput = Input.GetKey(KeyCode.LeftArrow);*/


        
        if (Input.touches.Length != 0)
        {
            Touch touch = Input.GetTouch(0);
            rightInput = touch.position.x > Screen.width / 2;
            leftInput = touch.position.x < Screen.width / 2;
        }
        else
        {
            rightInput = false;
            leftInput = false;
        }

        float direction = (rightInput ? 1f : 0f) - (leftInput ? 1f : 0f);

        rb.velocity = direction * transform.right * speed * Time.fixedDeltaTime;

        if (rightInput)
        {
            RaycastHit2D wallDetectRight = Physics2D.Raycast(transform.position, transform.right, 1f);

            if (wallDetectRight && wallDetectRight.collider.gameObject.name == "Environment")
            {
                transform.Rotate(new Vector3(0, 0, 90), Space.Self);
            }
        }
        if (leftInput)
        {
            RaycastHit2D wallDetectLeft = Physics2D.Raycast(transform.position, -transform.right, 1f);

            if (wallDetectLeft && wallDetectLeft.collider.gameObject.name == "Environment")
            {
                transform.Rotate(new Vector3(0, 0, -90), Space.Self);
            }
        }

    }

 void OnCollisionEnter(Collision hit){
     if (hit.gameObject.tag=="planet"){
         onPlanet=true;
     }
     if (hit.gameObject.tag=="okvir"){
         onPlanet=true;
     }
 }
 void OnCollisionExit(Collision hit){
     if (hit.gameObject.tag=="planet"){
         onPlanet=false;
     }
     if (hit.gameObject.tag=="okvir"){
         onPlanet=false;
     }
 }
}