using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCount : MonoBehaviour
{
    public int score = 0;
    public int totalSpawned;
    public int totalDestroyed;
    public double speedIncrease;
    public bool startStage = false;
    public GameObject ballExit;
    public GameObject exitSlime;
    public GameObject lastSlime1, lastSlime2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<trampolineCamera>().thisCamera.activeSelf)
        {
            startStage = true;
        }

        if (totalDestroyed + totalSpawned == 800 && score > 200)
        {
            ballExit.SetActive(false);
            exitSlime.SetActive(true);
            lastSlime1.SetActive(true);
            lastSlime2.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (FindObjectOfType<trampolineCamera>().thisCamera.activeSelf)
        {
            speedIncrease += 0.001;
        }
    }
}
