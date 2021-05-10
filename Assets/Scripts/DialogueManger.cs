using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManger : MonoBehaviour
{
    public GameObject canvas;
    public Text dialogueText;
    public Queue<string> sentences;
    public int sentenceCount;
    public bool active;
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        sentenceCount = sentences.Count;
    }

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

    void EndDialogue()
    {
        canvas.SetActive(false);
        active = false;
        Debug.Log("End of Convo");
    }
}
