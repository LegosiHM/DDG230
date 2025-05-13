using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardsPlayedPile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CardsManager cardsManager;
    public GameObject SelectedCard;
    public List<GameObject> Cards = new List<GameObject>();


    private void Update()
    {

        if (cardsManager.SelectedCard)
            SelectedCard = cardsManager.SelectedCard;
        else
            SelectedCard = null;
    }


public void OnPointerEnter(PointerEventData eventData)
    {
        cardsManager.HoveringMenu = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardsManager.HoveringMenu = null;
    }
}
