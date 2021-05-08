using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class Player : MonoBehaviourPun
{
    public new PhotonView photonView;
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public PhotonTransformView ptv;
    public CharacterController2D controller;
    public GameObject thisPlayer;

    public float runSpeed = 40f;
    public string color;
    float horizontalMove = 0f;

    bool jump = false;

    public bool stunned = false;
    public bool interactInput = false;

    public bool interactInputLong;

    private void Start()
    {
        if(photonView.IsMine)
        {
            animator = GetComponent<Animator>();   
        } else{
            rb.simulated = false;
        }
    }

    private void Update()
    {
        //Checks inputs of player
        if (photonView.IsMine)
        {
            CheckInput();
        }
    }
    private void CheckInput()
    {
        //Setting horizontal movement input value
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Sends horizontal movement input value to animator
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Gets input from the W key and sends boolean value to animator
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            interactInput = true;
        }
        else
        {
            interactInput = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            interactInputLong = true;
        }
        else
        {
            interactInputLong = false;
        }
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            if (stunned) { horizontalMove = 0; }
            //using the CharacterController variable 'controller', .Move gives velocity to character rigidbody
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    } 
    
    public void OnLanding(){

        animator.SetBool("IsJumping", false);
    }
    
}
