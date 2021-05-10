using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  Controls when dialouge is triggered
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManger DialogueMangager;
    public bool firstSign;
    public Player player;
    private bool firstSignTriggered = false;
    private bool contact;

    //Checks for input and state of dialogue when in contact with player
    //to either start or continue the dialogue
    private void Update()
    {
        if(contact)
        {
            if (player.interactInput)
            {
                if (DialogueMangager.active)
                {
                    DialogueMangager.DisplayNextSentence();
                } else
                {
                    DialogueMangager.StartDialogue(dialogue);
                    DialogueMangager.dialogueSource = gameObject;
                }
            }
        }
    }

    //Checks if collision is between the first sign which 
    //displays dialogue without need of input
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && firstSign && !firstSignTriggered)
        {
            DialogueMangager.StartDialogue(dialogue);
            firstSignTriggered = true;
        }
    }
    //Checks wether player is in contact with dialogue object
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            contact = true;
            if(player == null)
            {
                player = collision.GetComponent<Player>();
            }
        } else
        {
            contact = false;
            player = null;
        }

    }
    //Checks when player leaves contact with dialogue object
    private void OnTriggerExit2D(Collider2D collision)
    {
        contact = false;
        player = null;
    }
}
