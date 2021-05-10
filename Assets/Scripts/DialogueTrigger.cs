using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManger DialogueMangager;
    public bool firstSign;
    public Player player;
    private bool firstSignTriggered = false;
    private bool contact;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && firstSign && !firstSignTriggered)
        {
            DialogueMangager.StartDialogue(dialogue);
            firstSignTriggered = true;
        }
    }
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        contact = false;
        player = null;
    }
}
