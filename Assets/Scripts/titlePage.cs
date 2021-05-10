using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlePage : MonoBehaviour
{
    public GameObject toEnable, toDisable;

    public void enableDisable()
    {
        toEnable.SetActive(true);
        toDisable.SetActive(false);
    }
   
}
