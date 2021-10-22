using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameController : MonoBehaviour
{
    GameObject card;
    List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7 };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    int[] visibleFaces = { -1, -2 };
    
    void Start()
    {
        int originalLength = faceIndexes.Count;
        float xPosition = 0.27f;
        float yPosition = -0.81f;
        float zPosition = -0.57f;
        int columna = 1;
        for (int i = 0; i <= 15; i++)
        {
            if (i == (originalLength/4 ) * columna)
            {
                xPosition = 0.26f;
                zPosition -= 0.17f;
                columna++;
            }
            shuffleNum = rnd.Next(0, (faceIndexes.Count));
            var temp = Instantiate(card,transform.TransformPoint(new Vector3(xPosition, yPosition, zPosition)),
                    Quaternion.identity);
            temp.transform.rotation = card.transform.rotation;
            temp.GetComponent<CardController>().faceIndex = faceIndexes[shuffleNum];
            faceIndexes.Remove(faceIndexes[shuffleNum]);
            xPosition = xPosition - 0.13f;
            
        }
        //card.GetComponent<CardController>().faceIndex = faceIndexes[0];
    }

    public bool TwoCardsUp()
    {
        if((visibleFaces[0] >= 0) && (visibleFaces[1] >= 0))
        {
            return true;
        }
        return false;
    }

    public void AddVisibleFace(int index)
    {
        if(visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if(visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        return success;
    }

    private void Awake()
    {
        Debug.Log("Awake card controller");
        card = GameObject.Find("Loro1");
    }
}
