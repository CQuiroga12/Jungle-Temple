using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class used to pass a array of strings to DialougeManager
[System.Serializable]
public class Dialogue
{

    [TextArea(1,5)]
    public string[] sentences;

}
