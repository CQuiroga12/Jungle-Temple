using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeAttachment : MonoBehaviour
{
    public Player playerScript;
    public PhotonView pv;
    public Rigidbody2D thisRb;
    private bool attached = false;
    public float cooldown;
    public float exitForce;
    private bool timerOn;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (attached && playerScript.interactInput)
        {
            pv.RPC("detachRope", RpcTarget.All);
            timerOn = true;
        }
        if(timerOn)
        {
            cooldown -= Time.deltaTime;
        }
        if(cooldown<=0)
        {
            timerOn = false;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<Player>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerScript.interactInputLong && cooldown <= 0)
        {
            if (collision.gameObject.GetComponent<HingeJoint2D>() == null)
            {
                pv.RPC("attachRope", RpcTarget.All);
                cooldown = 0.5f;
            }          
        }
    }


    [PunRPC]
    void attachRope()
    {
        try
        {
            attached = true;
            playerScript.gameObject.AddComponent<HingeJoint2D>();
            playerScript.gameObject.GetComponent<HingeJoint2D>().connectedBody = thisRb;
        }
        catch (System.Exception)
        {

        }
    }

    [PunRPC]
    void detachRope()
    {
        try
        {
            attached = false;
            HingeJoint2D demo = playerScript.GetComponent<HingeJoint2D>();
            Destroy(demo);
            playerScript.GetComponent<Rigidbody2D>().AddForce(Vector3.up * exitForce);
        } catch (System.Exception)
        {
            
        }
    }
}
