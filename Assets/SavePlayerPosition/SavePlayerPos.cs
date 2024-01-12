using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPos : MonoBehaviour
{
    public Transform player;
    Vector3 playerPosition;

    void Start()
    {
        if (PlayerPrefs.HasKey("playerStarted"))
        {
            player.position = new Vector3(PlayerPrefs.GetFloat("playerPositionX"), PlayerPrefs.GetFloat("playerPosition2"));
        }

        if (!PlayerPrefs.HasKey("playerStarted"))
        {
            PlayerPrefs.SetInt("playerStarted", 1);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        playerPosition = player.position;
        PlayerPrefs.SetFloat("playerPositionx", playerPosition.x);
        PlayerPrefs.SetFloat("playerPositiony", playerPosition.y);
        PlayerPrefs.SetFloat("playerPositionz", playerPosition.z);
        PlayerPrefs.Save();
        Debug.Log("X:" + PlayerPrefs.GetFloat("playerPositionx") + "Y:" + PlayerPrefs.GetFloat("playerPositiony") + "Z:" + PlayerPrefs.GetFloat("playerPositionz"));
    }

}
