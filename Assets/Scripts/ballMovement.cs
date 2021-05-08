using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public Rigidbody2D thisRb;
    public double speed;
    public string color;
    public PhotonView pv;
    public scoreCount scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<scoreCount>();
        pv = gameObject.GetComponent<PhotonView>();
        speed *= UnityEngine.Random.Range(0.8f, 2.0f);
        speed += scoreKeeper.speedIncrease;
        thisRb.AddForce(Vector2.right * (float)speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(color == collision.gameObject.GetComponent<Player>().color)
            {
                pv.RPC("destroyBall", RpcTarget.All);
                FindObjectOfType<scoreCount>().score++;
            }
        }
        if (collision.gameObject.CompareTag("BallDespawn"))
        {
            pv.RPC("destroyBall", RpcTarget.All);
        }
    }

    [PunRPC]
    void destroyBall()
    {
        try 
        { 
            PhotonNetwork.Destroy(pv);
            FindObjectOfType<scoreCount>().totalDestroyed++;
        }
        catch (Exception) { }
       
    }
}
