using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeController : MonoBehaviour
{
    public Player playerScript;
    public bool contact = false;
    public bool spaceRight = true, spaceLeft = true;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerScript = collision.gameObject.GetComponent<Player>();
            contact = true;
        }else 
        {
            contact = false;
        }
    }
}
