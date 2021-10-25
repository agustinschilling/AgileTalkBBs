using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class TiempoCartas : MonoBehaviour
{

    private bool comenzo = false;
    public TextMeshPro textmeshPro;
    public float count = 99.0f;
    private GameObject cardGameController;
    
    void Start()
    {
        this.cardGameController = GameObject.Find("Juego de cartas");
        this.textmeshPro = this.gameObject.GetComponent<TextMeshPro>();
    }
    void Update()
    {
        if (comenzo) {
            this.textmeshPro.text = this.count.ToString("00");
            count = count - 1 * Time.deltaTime;
        }
    }

    public void Stop() {
        this.cardGameController.GetComponent<CardGameController>().comenzoJuego = false;
    }

    private void OnMouseDown()
    {
        comenzo = !comenzo;
    }

    public int getTiempo() {
        return (int)Math.Round(count);;
    }
}