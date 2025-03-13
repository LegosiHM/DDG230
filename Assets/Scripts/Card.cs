using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool IsDragging;
    public bool CanDrag;
    public bool Played;
    Canvas canvas;
    public CardsManager cardsManager;

    public CardsPlayedPile cardsPlayedPile;

    private void Start()
    {
        
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        cardsManager = GameObject.Find("CardsManager").GetComponent<CardsManager>();
        cardsPlayedPile = GameObject.Find("CardsPlayedTable").GetComponent<CardsPlayedPile>();


        gameObject.name = transform.parent.name;

        cardsManager.cardsLayoutGroup.Cards.Add(gameObject);
        CanDrag = true;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CanDrag)
        {
            cardsManager.SelectedCard = gameObject;

            //Set booleans
            IsDragging = true;

            //cardsManager.GetComponent<AudioSource>().Play();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CanDrag)
        {
            //Dragging the object
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, Input.mousePosition, canvas.worldCamera, out position);
            transform.position = canvas.transform.TransformPoint(position);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (cardsManager.HoveringMenu.name.Contains("Discard"))
        {
            CanDrag = false;
            cardsManager.SelectedCard = null;

            transform.parent.position = cardsManager.HoveringMenu.transform.position;
            transform.parent.SetParent(cardsManager.HoveringMenu.transform);

            transform.position = transform.parent.position;

            cardsManager.cardsLayoutGroup.Cards.Remove(gameObject);
        }

        if (cardsManager.HoveringMenu.name.Contains("Played"))
        {
            if(cardsPlayedPile.Cards.Count > 0)
            {
                GameObject prevCard = cardsPlayedPile.Cards[cardsPlayedPile.Cards.Count - 1];
                string prevCardCode = prevCard.name;
                if (gameObject.name[0] == prevCardCode[prevCardCode.Length - 1]) 
                {
                    CanDrag = true;
                    Played = true;
                    cardsManager.SelectedCard = null;

                    transform.parent.position = cardsManager.HoveringMenu.transform.position;
                    transform.parent.SetParent(cardsManager.HoveringMenu.transform);
                    transform.parent.SetSiblingIndex(cardsManager.HoveringMenu.transform.childCount);

                    transform.position = transform.parent.position;

                    cardsManager.cardsLayoutGroup.Cards.Remove(gameObject);

                    cardsPlayedPile.Cards.Add(gameObject);
                }
                else
                {
                    cardsManager.SelectedCard = null;
                    transform.position = transform.parent.position;
                }
            }
            else
            {
                CanDrag = true;
                Played = true;
                cardsManager.SelectedCard = null;

                transform.parent.position = cardsManager.HoveringMenu.transform.position;
                transform.parent.SetParent(cardsManager.HoveringMenu.transform);
                transform.parent.SetSiblingIndex(cardsManager.HoveringMenu.transform.childCount);

                transform.position = transform.parent.position;

                cardsManager.cardsLayoutGroup.Cards.Remove(gameObject);

                cardsPlayedPile.Cards.Add(gameObject);
            }

            
        }
       
        else
        {
            cardsManager.SelectedCard = null;
            transform.position = transform.parent.position;
        }

        //cardsManager.GetComponent<AudioSource>().Play();

        //Set booleans
        IsDragging = true;
    }
}
