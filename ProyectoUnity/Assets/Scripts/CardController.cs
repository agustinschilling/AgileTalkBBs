using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardController : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    private Animator cardAnimator;
    //public Sprite[] faces;
    public bool isFigure = false;
    public int faceIndex;
    public bool matched = false;

    public void OnMouseDown()
    {
        if (matched == false)
        {
            if (isFigure == false)
            {
                if (gameControl.GetComponent<CardGameController>().TwoCardsUp() == false)
                {
                    //spriteRenderer.sprite = faces[faceIndex];
                    isFigure = true;
                    this.cardAnimator.SetTrigger("Girar_Dorso_Figura");
                    
                    gameControl.GetComponent<CardGameController>().AddVisibleFace(faceIndex);
                    matched = gameControl.GetComponent<CardGameController>().CheckMatch();
                }
            }
            else
            {
                //spriteRenderer.sprite = back;
                this.cardAnimator.SetTrigger("Girar_Figura_Dorso");
                isFigure = false;
                gameControl.GetComponent<CardGameController>().RemoveVisibleFace(faceIndex);
            }
        }
    }

    
    private void Awake()
    {
        Debug.Log("Awake card");
        this.cardAnimator = this.gameObject.GetComponent<Animator>();
        this.cardAnimator.transform.Rotate(0,90,180);
        gameControl = GameObject.Find("Juego de cartas");
    }
}
