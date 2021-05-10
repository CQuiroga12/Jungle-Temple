using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Photon.Pun;

/*Activates and deactivates the colliders two set tilemaps
 * and changes there colors to be more faded or more solid based on it
 */
public class PlatformEnabler : MonoBehaviour
{
    public Player playerScript;
    public Tilemap SetA;
    public Tilemap SetB;
    private bool contact = false;
    private bool currentSet = false;
    private bool interactCheck;
    private PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        SetA.GetComponent<Rigidbody2D>().Sleep();
        SetA.GetComponent<TilemapCollider2D>().enabled = false;
        SetA.color = new Color(SetA.color.r, SetA.color.g, SetA.color.b, 0.1f);
    }

    //Checks for contact with player and gets Player script from collision
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<Player>();
            contact = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        contact = false;
    }

    //If player is in contact and inputting then calls RPC
    //to switch the two tilesets active state
    private void Update()
    {
        if(contact && playerScript.interactInput)
        {
            PV.RPC("swapPlatform", RpcTarget.All);
        }

    }

    //RPC of 2 tilemap sets that ensures server wide changes to active state of colliders
    [PunRPC]
    void swapPlatform()
    {
        if (currentSet)
        {
            SetB.GetComponent<Rigidbody2D>().Sleep();
            SetB.GetComponent<TilemapCollider2D>().enabled = false;
            SetB.color = new Color(SetB.color.r, SetB.color.g, SetB.color.b, 0.1f);
            SetA.GetComponent<Rigidbody2D>().WakeUp();
            SetA.GetComponent<TilemapCollider2D>().enabled = true;
            SetA.color = new Color(SetA.color.r, SetA.color.g, SetA.color.b, 1.0f);
            currentSet = false;
        }
        else
        {
            SetA.GetComponent<Rigidbody2D>().Sleep();
            SetA.GetComponent<TilemapCollider2D>().enabled = false;
            SetA.color = new Color(SetA.color.r, SetA.color.g, SetA.color.b, 0.1f);
            SetB.GetComponent<Rigidbody2D>().WakeUp();
            SetB.GetComponent<TilemapCollider2D>().enabled = true;
            SetB.color = new Color(SetB.color.r, SetB.color.g, SetB.color.b, 1.0f);
            currentSet = true;
        }
    }
}
