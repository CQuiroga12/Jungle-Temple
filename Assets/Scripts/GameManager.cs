using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

//Spawns Players and sets a main camera to each of them
public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    CameraFollow cameraFollow;
    public Vector2 spawnPosition;

    //Activates main canvas that contains start button
    private void Awake()
    {
        GameCanvas.SetActive(true);
    }

    //Insantiates a player and sets a camera to follow them
    //Spawn Location is based on player spawn order
    public void SpawnPlayer()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
        if (FindObjectsOfType<Player>().Length == 1){
            Debug.Log("Player2 Spawning");
            spawnPosition = GameObject.Find("Player2Spawn").transform.position;
            GameObject Player = PhotonNetwork.Instantiate("EC_PlayerGreen", spawnPosition, Quaternion.identity, 0);
            cameraFollow.SetCameraTarget(Player.transform);
        } else {
            Debug.Log("Player2 Spawning");
            spawnPosition = GameObject.Find("Player1Spawn").transform.position;
            GameObject Player = PhotonNetwork.Instantiate("EC_PlayerBlue", spawnPosition, Quaternion.identity, 0);
            cameraFollow.SetCameraTarget(Player.transform);
        }
        Debug.Log("Player Spawned");
    }

}
