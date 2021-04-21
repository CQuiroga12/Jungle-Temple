using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject GameCanvas;
    public GameObject SceneCamera;
<<<<<<< Updated upstream
    public int PlayerCount = 0;
=======
    public int PlayerCount;
>>>>>>> Stashed changes

    private void Awake()
    {
        GameCanvas.SetActive(true);
    }
    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);
<<<<<<< Updated upstream
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
=======

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("Preparing to Spawn Player 1");
            PhotonNetwork.Instantiate("EC_Player1", new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
            Debug.Log("Spawned Player 1");
            GameCanvas.SetActive(false);
            SceneCamera.SetActive(false);
            PlayerCount++;

        } else{
            Debug.Log("Preparing to Spawn Player 2");
            PhotonNetwork.Instantiate("EC_Player2", new Vector2(this.transform.position.x * randomValue, this.transform.position.y), Quaternion.identity, 0);
            Debug.Log("Spawned Player 2");
            GameCanvas.SetActive(false);
            SceneCamera.SetActive(false);
            PlayerCount++;
>>>>>>> Stashed changes
        }
    }

}
