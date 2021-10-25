using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Tiempo : MonoBehaviour
{

    public TextMeshPro textmeshPro;
    public float count = 99.0f;

    public static bool stop = false; // aca va el tema del true

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop) {
            textmeshPro.SetText("Tiempo: " + count.ToString("f0"));
            count = count - 1 * Time.deltaTime;
        }
    }

    public void Stop() {
        stop = true;
    }

    public int getTiempo() {
        return (int)Math.Round(count);;
    }

    public void PlayGame() {
        stop = false;
    }
}
