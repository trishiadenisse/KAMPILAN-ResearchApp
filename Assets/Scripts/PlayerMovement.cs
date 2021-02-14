﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;



    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       if (Input.GetButtonDown("Jump"))
       {
                jump =true;
       }
    }

    void FixedUpdate()
    {
        //Move our character in a fixed amount of time

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump =false;
    }
}
