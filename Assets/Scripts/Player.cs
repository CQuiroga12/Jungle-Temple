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

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;


    private void Awake()
    {
        if(photonView.IsMine)
        {
            PlayerCamera.SetActive(true);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            CheckInput();
        }
    }
    private void CheckInput()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
    public void OnLanding(){

        animator.SetBool("IsJumping", false);
    }
    
}
