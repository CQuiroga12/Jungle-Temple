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
    public int PlayerCount = 0;

    private void Awake()
    {
        GameCanvas.SetActive(true);
    }
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);
        if (PlayerCount == 0){
            Debug.Log("Player1 Spawning");
            PhotonNetwork.Instantiate("EC_Player1", new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
            Debug.Log("Player1 Spawned");
            GameCanvas.SetActive(false);
            SceneCamera.SetActive(false);
            PlayerCount++;
        } else {
            Debug.Log("Player2 Spawning");
            PhotonNetwork.Instantiate("EC_Player2", new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
            Debug.Log("Player2 Spawned");
        }
    }

}
