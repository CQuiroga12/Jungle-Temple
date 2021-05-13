using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTrial : MonoBehaviour
{
    public Player playerScript;
    public GameObject trialSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<Player>();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(playerScript!=null)
        {
            if (playerScript.qkeyDown)
            {
                playerScript.gameObject.transform.position = trialSpawn.transform.position;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerScript = null;
        }
    }
}
