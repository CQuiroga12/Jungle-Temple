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
    public bool gameLost, gameWon;

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<trampolineCamera>().thisCamera.activeSelf)
        {
            startStage = true;
        }

        if (totalDestroyed + totalSpawned == 800)
        {
            if (score >= 200)
            {
                gameWon = true;
                ballExit.SetActive(false);
                exitSlime.SetActive(true);
                lastSlime1.SetActive(true);
                lastSlime2.SetActive(true);
                startStage = false;
            } else if (score <200)
            {
                gameLost = true;
            }
        }

        if(gameLost)
        {
            score = 0;
            totalDestroyed = 0;
            totalSpawned = 0;
            gameLost = false;
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
