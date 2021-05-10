using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Changes position of the slime this is attached to based on player Input
public class movingSlime : MonoBehaviour
{
    public GameObject leftLimit, rightLimit;
    public slimeController slimeController;
    public Transform thisTransform;
    public float slimeSpeed;
    public Player playerScript;
    public PhotonView pv;
    private bool movingRight, movingLeft;

    void Start()
    {
        playerScript = FindObjectOfType<Player>();
    }

    //Checks for contact on controller and gets player script from
    //collision. Then checks for input to move right or left or neither.
    void Update()
    {
        if (slimeController.contact)
        {
            if (playerScript == null)
            {
                playerScript = slimeController.playerScript;
            }

            if (playerScript.interactInputLong)
            {
                movingRight = true;
                movingLeft = false;
            }
            else if (playerScript.qkeyDown)
            {
                movingLeft = true;
                movingRight = false;
            }
            else
            {
                movingRight = false;
                movingLeft = false;
            }
        }
    }

    //If moving right/left is true and the slime has
    //enough space, calls RPC that changes positon of slime
    private void FixedUpdate()
    {
        if (movingLeft && slimeController.spaceLeft)
        {
            pv.RPC("moveSlimeLeft", RpcTarget.All);
        }
        else if (movingRight && slimeController.spaceRight)
        {
            pv.RPC("moveSlimeRight", RpcTarget.All);
        }
    }

    //Checks to see if theres space to the right and left of the slime
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == leftLimit)
        {
            slimeController.spaceLeft = false;
        }
        else if (collision.gameObject == rightLimit)
        {
            slimeController.spaceRight = false;
        }
    }

    // Checks to see if slime has stopped touching its limiter
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == leftLimit)
        {
            slimeController.spaceLeft = true;
        }
        else if (collision.gameObject == rightLimit)
        {
            slimeController.spaceRight = true;
        }
    }

    //Changes slime's position based on slimeSpeed
    [PunRPC]
    void moveSlimeRight()
    {
        thisTransform.position += Vector3.right * slimeSpeed;
    }

    [PunRPC]
    void moveSlimeLeft()
    {
        thisTransform.position += Vector3.left * slimeSpeed;
    }

}
