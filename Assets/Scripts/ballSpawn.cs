using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Spawns balls if player has reached the ball stage and the amount
 * of balls spawned is below the limit. Spawn rate is a random chance that increases
 * at a constant rate over time. Speed is randomly selected within a range and increased
 * at a constant rate over time. Also adds to total amount spawned in scoreCount script.
 */
public class ballSpawn : MonoBehaviour
{
    public Transform thisTransform;
    public double spawnChance;
    private bool spawning;
    private scoreCount scoreKeeper;

    // Getting the scoreCount script
    void Start()
    {
        scoreKeeper = FindObjectOfType<scoreCount>();
    }

    //Checking if balls spawned has reached the limit and if
    //player has reached the stage
    void Update()
    {
        
        if (scoreKeeper.totalSpawned < 400 && scoreKeeper.startStage)
        {
            spawning = true;
        } else
        {
            spawning = false;
        }
    }

    //Spawning balls
    private void FixedUpdate()
    {
        
        if (spawning)
        {
            //SpawnChance increased at a constant rate
            spawnChance += 0.0001;
            float rng = Random.Range(0f, 100f);
            if (rng <= spawnChance)
            {
                float rng2 = Random.Range(0f, 1f);
                if (rng2 < 0.5f)
                {
                    PhotonNetwork.Instantiate("GreenBallPoint", thisTransform.position, Quaternion.Euler(0, 0, 90), 0);
                }
                else
                {
                    PhotonNetwork.Instantiate("BlueBallPoint", thisTransform.position, Quaternion.Euler(0, 0, 90), 0);
                }

                //Adds to total amount spawned
                scoreKeeper.totalSpawned++;
            }
        }
    }
}
