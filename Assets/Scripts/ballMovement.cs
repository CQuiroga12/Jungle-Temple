using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    /* Tracks the balls for collisions of either player or a wall that destroys them
     * Calls a RPC function that destroys itself upon collision of either 
     * also adds to Score keeper's score count upon destruction
     */
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

    //First check if collision is with player and then if its the
    //correct player based on color. Then check if collision is on 
    //wall that destroys the balls. Call a RPC method to destroy and add score
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

    //Destroy the ball with RPC to ensure serverwide destruction
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
