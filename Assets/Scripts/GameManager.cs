using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject GameCanvas;
    public GameObject SceneCamera;
    CameraFollow cameraFollow;
    public Vector2 spawnPosition;

    private void Awake()
    {
        GameCanvas.SetActive(true);
    }
    public void SpawnPlayer()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
        if (PhotonNetwork.CountOfPlayersInRooms == 0){
            Debug.Log("Player1 Spawning");
            spawnPosition = GameObject.Find("Player1Spawn").transform.position;
        } else {
            Debug.Log("Player2 Spawning");
            spawnPosition = GameObject.Find("Player2Spawn").transform.position;
        }
        GameObject Player = PhotonNetwork.Instantiate("EC_Player1", spawnPosition, Quaternion.identity, 0);
        cameraFollow.SetCameraTarget(Player.transform);
        Debug.Log("Player Spawned");
    }

}
