using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CardController : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    private Animator cardAnimator;
    public bool isFigure = false;
    public bool matched = false;
    public string nameCard;
    public void OnMouseDown()
    {
        if (matched == false)
        {
            if (isFigure == false)
            {
                if (gameControl.GetComponent<CardGameController>().TwoCardsUp() == false)
                {
                    this.isFigure = true;
                    this.cardAnimator.SetTrigger("Girar_Dorso_Figura");
                    gameControl.GetComponent<CardGameController>().AddVisibleFace(this);
                    gameControl.GetComponent<CardGameController>().CheckMatch();
                }
                
            }
            else
            {
                this.cardAnimator.SetTrigger("Girar_Figura_Dorso");
                this.isFigure = false;
                gameControl.GetComponent<CardGameController>().RemoveVisibleFace(this);
            }
        }
    }

    public void girarFigura()
    {
        this.cardAnimator.SetTrigger("Girar_Figura_Dorso");
        this.isFigure = false;
        gameControl.GetComponent<CardGameController>().RemoveVisibleFace(this);
    }
    private void Awake()
    {
        this.cardAnimator = this.gameObject.GetComponent<Animator>();
        gameControl = GameObject.Find("Juego de cartas");
    }
}
