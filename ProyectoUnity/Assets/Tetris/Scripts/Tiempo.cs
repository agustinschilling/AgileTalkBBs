using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{

    public TextMeshPro textmeshPro;
    public float count = 99.0f;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
         textmeshPro.SetText("Tiempo: " + count.ToString("f0"));
         count = count - 1 * Time.deltaTime;
    }
}
