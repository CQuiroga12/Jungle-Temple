using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
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
}
