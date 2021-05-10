using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
