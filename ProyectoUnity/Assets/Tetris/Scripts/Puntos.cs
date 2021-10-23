using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{

    public TextMeshPro textmeshPro;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        textmeshPro.SetText("Puntos: " + count.ToString());
    }

    public void Sumar() {
        count++;
    }

}

