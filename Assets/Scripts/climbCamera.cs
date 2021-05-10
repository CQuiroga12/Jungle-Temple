using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Switches the active camera when a trigger is collided
 * Has a camera to switch too along with checking 3 other cameras
 * before setting the main camera active
 */
public class climbCamera : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject thisCamera;
    public GameObject o1Camera;
    public GameObject o2Camera;
    public GameObject o3Camera;
    private int players;

    //Switches camera to thisCamera when collider is triggered
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

    //Checks o1-3 to see if they are active before switching to main camera
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
