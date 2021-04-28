using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformEnabler : MonoBehaviour
{
    public Player playerScript;
    public Tilemap SetA;
    public Tilemap SetB;
    private bool contact = false;
    private bool currentSet = false;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<Player>();
            contact = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        contact = false;
    }

    private void Update()
    {
        if(contact && playerScript.interactInput)
        {
            Debug.Log("INPUTED");
            if (currentSet)
            {
                SetB.GetComponent<Rigidbody2D>().Sleep();
                SetB.color = new Color(SetB.color.r, SetB.color.g, SetB.color.b, 0.1f);
                SetA.GetComponent<Rigidbody2D>().WakeUp();
                SetA.color = new Color(SetA.color.r, SetA.color.g, SetA.color.b, 1.0f);
                currentSet = false;
            }
            else
            {
                SetA.GetComponent<Rigidbody2D>().Sleep();
                SetA.color = new Color(SetA.color.r, SetA.color.g, SetA.color.b, 0.1f);
                SetB.GetComponent<Rigidbody2D>().WakeUp();
                SetB.color = new Color(SetB.color.r, SetB.color.g, SetB.color.b, 1.0f);
                currentSet = true;
            }
        }
    }

}
