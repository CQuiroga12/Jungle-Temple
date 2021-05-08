using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject thisCamera;
    private int players;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            players++;
            if (players == 2)
            {
                mainCamera.SetActive(false);
                thisCamera.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            players--;
            if (players == 0)
            {
                thisCamera.SetActive(false);
                mainCamera.SetActive(true);
            }
        }
    }
}
