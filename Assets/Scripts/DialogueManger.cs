using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Displays dialogue when prompted and keeps a queue of
 * the sentances that will be displayed.
 */
public class DialogueManger : MonoBehaviour
{
    public GameObject canvas;
    public Text dialogueText;
    public Queue<string> sentences;
    public int sentenceCount;
    public bool active;
    public GameObject dialogueSource;

    void Start()
    {
        sentences = new Queue<string>();
    }

    //Updating the sentance count thats used to check state of dialouge
    void Update()
    {
        sentenceCount = sentences.Count;
    }

    //Clears queue then enqueus all the sentences from the passed dialogue
    //before displaying the first, also sets textbox to active
    public void StartDialogue(Dialogue dialogue)
    {
        canvas.SetActive(true);
        active = true;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    //Dequeue and displays the next string in the queue or calls for EndDialogue if 
    //there is none left
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;


    }

    //Deactivated text box and clears sentance queue
    public void EndDialogue()
    {
        canvas.SetActive(false);
        active = false;
        sentences.Clear();
    }
}
