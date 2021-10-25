using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CardGameController : MonoBehaviour
{
    GameObject card;
    public bool comenzoJuego = false;
    private int aciertos = 0;
    private int fallos = 0;
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    CardController[] visibleFaces = { null, null};
    private List<String> cartas = new List<String>
    {
        "Card0","Card0","Card1","Card1","Card2","Card2","Card3","Card3",
        "Card4","Card4","Card5","Card5","Card6","Card6","Card7","Card7"
    };

    void Start()
    {
        int originalLength = cartas.Count;
        float xPosition = 0.27f;
        float yPosition = -0.90f;
        float zPosition = 0.1f;
        int columna = 1;
        for (int i = 0; i <= 15; i++)
        {
            if (i == (originalLength/4 ) * columna)
            {
                xPosition = 0.27f;
                zPosition -= 0.17f;
                columna++;
            }
            shuffleNum = rnd.Next(0, (cartas.Count));
            var temp = Instantiate(GameObject.Find(cartas[shuffleNum]),transform.TransformPoint(new Vector3(xPosition, yPosition, zPosition)),
                    Quaternion.identity);
            temp.GetComponent<CardController>().nameCard = cartas[shuffleNum];
            this.cartas.Remove(cartas[shuffleNum]);
            xPosition = xPosition - 0.13f;
            
        }
    }

    public bool TwoCardsUp()
    {
        if((visibleFaces[0] != null) && (visibleFaces[1] != null))
        {
            return true;
        }
        return false;
    }

    public void AddVisibleFace(CardController obj)
    {
        if(visibleFaces[0] == null)
        {
            visibleFaces[0] = obj;
        }
        else if (visibleFaces[1] == null)
        {
            visibleFaces[1] = obj;
        }
    }

    public void RemoveVisibleFace(CardController obj)
    {
        if (visibleFaces[0] == obj)
        {
            visibleFaces[0] = null;
        }
        else if (visibleFaces[1] == obj)
        {
            visibleFaces[1] = null;
        }
    }

    public void CheckMatch()
    {
        if (TwoCardsUp())
        {
            if(visibleFaces[0].nameCard == visibleFaces[1].nameCard)
            {
                aciertos++;
                visibleFaces[0].matched = true;
                visibleFaces[1].matched = true;
                visibleFaces[0] = null;
                visibleFaces[1] = null;
            }
            else
            {
                fallos++;
                visibleFaces[0].matched = false;
                visibleFaces[1].matched = false;
                visibleFaces[0].girarFigura();
                visibleFaces[1].girarFigura();
            }
        }
    }

    public void comenzarJuego()
    {
        this.comenzoJuego = true;
    }

    public bool getComenzo()
    {
        return this.comenzoJuego;
    }
}
