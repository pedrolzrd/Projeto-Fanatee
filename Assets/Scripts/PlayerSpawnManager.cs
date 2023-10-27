using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviour
{
    [Header("Player Attributes")]
    public Transform[] spawnLocations; //Onde os players nascem.
    public GameObject[] circleImages; //O Ui que fica embaixo do pé dos players.
    public string[] tagsToAssing; //Tags para setar no player.

    [Space(15)] // 15 pixels of spacing here.

    [Header("Activations")]
    public GameObject timePowerUpSpawn;
    public GameObject numberSpawner;
    public GameObject powerupSpawner;
    public GameObject coin;
    public GameObject countDowntimer;
    [Space(15)] // 15 pixels of spacing here.
    public GameObject slowTerrain;
    public GameObject slowTerrain2;
    public GameObject slowTerrain3;
    public GameObject cutscene;
    public GameObject numberCollector;

    public TextMeshProUGUI pressAtoJoinText;
    void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("PlayerInput ID: " + playerInput.playerIndex);

        //Seta o player ID, adiciona um ao index ao start o player 
        playerInput.gameObject.GetComponent<PlayerDetails>().playerID = playerInput.playerIndex + 1;

        //Seta o start Spawn Location do player usando a localização usando a referencia dentro do Array no Inspector.
        playerInput.gameObject.GetComponent<PlayerDetails>().startPos = spawnLocations[playerInput.playerIndex].position;

        //Seta o Circle Image que sao objetos no array.
        playerInput.gameObject.GetComponent<PlayerDetails>().circleImage = circleImages[playerInput.playerIndex];

        //Seta a Tag pelo array de Strings alimentado no Inspector.
        playerInput.gameObject.GetComponent<PlayerDetails>().playerTag = tagsToAssing[playerInput.playerIndex];

        //Index começa em 0 entao, qunado o index é 1 quer dizer que dois players nasceram, ativando os objetos a seguir.
        if(playerInput.playerIndex == 1 ) {

            cutscene.SetActive(true);
            timePowerUpSpawn.SetActive(true);
            powerupSpawner.SetActive(true);
            numberSpawner.SetActive(true); 
            coin.SetActive(true);
            countDowntimer.SetActive(true);

            /*slowTerrain.SetActive(true);
            slowTerrain2.SetActive(true);
            slowTerrain3.SetActive(true);*/


            numberCollector.SetActive(true);

            pressAtoJoinText.gameObject.SetActive(false);

        }

    }
    
}
