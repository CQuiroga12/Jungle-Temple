using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject thisCamera;
    public GameObject o1Camera;
    public GameObject o2Camera;
    public GameObject o3Camera;
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
                if (o1Camera.activeSelf == false && o2Camera.activeSelf == false && o3Camera.activeSelf == false)
                {
                    mainCamera.SetActive(true);
                }
            }
        }
    }

}
