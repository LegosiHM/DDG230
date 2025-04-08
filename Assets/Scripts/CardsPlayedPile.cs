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

        /*
        if (SelectedCard)
        {
            if (cardsManager.HoveringMenu == gameObject)
            {
                for (int i = 0; i < Cards.Count; i++)
                {
                    if (SelectedCard.transform.position.x > Cards[i].transform.position.x)
                    {
                        if (SelectedCard.transform.parent.GetSiblingIndex() < Cards[i].transform.parent.GetSiblingIndex())
                        {
                            //SwapCards(SelectedCard, Cards[i]);
                            break;
                        }
                    }

                    /*if (SelectedCard.transform.position.x < Cards[i].transform.position.x)
                    {
                        if (SelectedCard.transform.parent.GetSiblingIndex() > Cards[i].transform.parent.GetSiblingIndex())
                        {
                            //SwapCards(SelectedCard, Cards[i]);
                            break;
                        }
                    }
                    
                }
            }
        */

    

    /*
    Card[] playedCard = gameObject.GetComponentsInChildren<Card>();

    foreach (Card card in playedCard)
    {
        if (Cards.Contains(card.gameObject))
        {
            Debug.Log("repeat");
            continue;
        }
        else
        {
            Cards.Add(card.gameObject); ;
        }
    }
    */


}

/*
    public void SwapCards(GameObject currentCard, GameObject targetCard)
    {
        
        Transform currentCardParent = currentCard.transform.parent;
        Transform targetedCardParent = targetCard.transform.parent;

        currentCard.transform.SetParent(targetedCardParent);
        targetCard.transform.SetParent(currentCardParent);

        if (!currentCard.transform.GetComponent<Card>().IsDragging)
        {
            currentCard.transform.localPosition = Vector2.zero;
        }

        targetCard.transform.localPosition = Vector2.zero;

        //GetComponent<AudioSource>().Play();
        
    }
*/

public void OnPointerEnter(PointerEventData eventData)
    {
        cardsManager.HoveringMenu = gameObject;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardsManager.HoveringMenu = null;
    }
}
