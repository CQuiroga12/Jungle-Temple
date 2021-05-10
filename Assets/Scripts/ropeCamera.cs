using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject thisCamera;
    public GameObject o1Camera;
    private int players;
    // Start is called before the first frame update
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
                if (o1Camera.activeSelf == false)
                {
                    mainCamera.SetActive(true);
                }
            }
        }
    }

}
