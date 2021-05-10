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
    public DialogueManger DialogueManager;

    public float runSpeed = 40f;
    public string color;
    float horizontalMove = 0f;

    bool jump = false;

    public bool stunned = false;
    public bool interactInput = false;

    public bool interactInputLong;

    public bool qkeyDown;

    //Checks if the photon view is yours and if it isnt
    //then your rigidbody stops getting stimulated in order to 
    //preserve fluidity of non-local characters
    private void Start()
    {
        if(photonView.IsMine)
        {
            animator = GetComponent<Animator>();   
        } else{
            rb.simulated = false;
        }

        DialogueManager = FindObjectOfType<DialogueManger>().GetComponent<DialogueManger>();
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

        if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
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

        if(Input.GetKey(KeyCode.Q))
        {
            qkeyDown = true;
        }
        else
        {
            qkeyDown = false;
        }
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine && DialogueManager.sentences.Count == 0)
        {
            if (stunned) { horizontalMove = 0; }
            //using the CharacterController variable 'controller', .Move gives velocity to character rigidbody
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        } else if(DialogueManager.sentences.Count != 0)
        {
            rb.velocity = Vector3.zero;
        }
    } 
    
    public void OnLanding(){

        animator.SetBool("IsJumping", false);
    }
    
}
