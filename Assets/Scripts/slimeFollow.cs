using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeFollow : MonoBehaviour
{
    public Player playerScript;
    public Animator animator;
    public Transform target;
    public Transform thisTransform;
    public float launchForce;
    public float offset;
    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;
    public bool contact = false;
    private Transform targetHolder;
    public bool equipped = false;
    private PhotonView PV;

    // Start is called before the first frame update
    private void Start()
    {
        
        PV = GetComponent<PhotonView>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contact = true;

            if (!equipped)
            {
                Debug.Log("Contact");
                playerScript = collision.gameObject.GetComponent<Player>();
                Debug.Log(playerScript.gameObject.name);
            }

            if(equipped)
            {
                Debug.Log("Bounce");
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * launchForce;
                animator.SetBool("Bounce", true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerScript.interactInputLong)
        {
            targetHolder = collision.gameObject.GetComponent<Transform>();
            PV.RPC("setSlimeTarget", RpcTarget.All);
            equipped = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contact = false;
    }

    private void Update()
    {
        animator.SetBool("Bounce", false);
    }

    private void FixedUpdate()
    {
        if(equipped)
        {
            PV.RPC("slimeTracker", RpcTarget.All);
        }
    }

    [PunRPC]
    void slimeTracker()
    {
        equipped = true;
        try
        {
            Vector3 newPosition = target.position + new Vector3(0, offset);
            thisTransform.position = Vector3.Slerp(thisTransform.position, newPosition, smoothFactor);
        } catch(System.Exception)
        {
            
        }
    }

    [PunRPC]
    void setSlimeTarget()
    {
        target = targetHolder;
    }
}
