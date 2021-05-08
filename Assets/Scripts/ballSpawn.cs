using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawn : MonoBehaviour
{
    public Transform thisTransform;
    public double spawnChance;
    private bool spawning;
    private scoreCount scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<scoreCount>();
    }

    // Update is called once per frame
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
    private void FixedUpdate()
    {
        
        if (spawning)
        {
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
                scoreKeeper.totalSpawned++;
            }
        }
    }
}
