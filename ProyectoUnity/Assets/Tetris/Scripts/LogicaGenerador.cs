using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaGenerador : MonoBehaviour
{

    public GameObject[] figuras;

    // Start is called before the first frame update
    void Start()
    {
        NuevaFigura(0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NuevaFigura(float scale) {
        //Instantiate(figuras[Random.Range(0, figuras.Length)], transform.position, Quaternion.identity); 

        GameObject newObject = Instantiate(figuras[Random.Range(0, figuras.Length)], transform.position, Quaternion.identity) as GameObject;  // instatiate the object
        newObject.transform.localScale = new Vector3(scale, scale, scale);

    }
}
