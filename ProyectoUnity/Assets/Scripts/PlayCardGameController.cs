using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCardGameController : MonoBehaviour
{
    public GameObject camera;
    public GameObject cameraPlayer;
    private bool jugando;
    public GameObject player;
    public PlayerController PlayerController;
    private void Start()
    {
        this.camera.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!jugando && Input.GetKeyDown(KeyCode.E))
        { 
            this.camera.SetActive(true);
            this.cameraPlayer.SetActive(false);
            this.PlayerController.setCursor(true);
            this.jugando = true;
            this.player.SetActive(false);
        }
        else if (jugando && Input.GetKeyDown(KeyCode.E))
        {
            this.camera.SetActive(false);
            this.cameraPlayer.SetActive(true);
            this.PlayerController.setCursor(false);
            this.jugando = false;
            this.player.SetActive(true);
        }
    }
    
}
