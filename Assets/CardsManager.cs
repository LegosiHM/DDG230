using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public GameObject SelectedCard;
    public GameObject HoveringMenu;

    public CardsLayoutGroup cardsLayoutGroup;

    public GameObject CardParent;
    public List<GameObject> CardPool = new List<GameObject>();
    private List<GameObject> DiscardPool = new List<GameObject>();

    [SerializeField] private int CardCount = 4;
    int i = 0;
    int fullCardPool;



    private void Start()
    {
        fullCardPool = CardPool.Count;
        AddCard();
    }

    public void AddCard()
    {
        if(CardPool.Count < CardCount - cardsLayoutGroup.transform.childCount) //if pool < empty hand
        {
            while (i < fullCardPool && DiscardPool.Count > 0) //reset pool
            {
                CardPool.Add(DiscardPool[0]);
                DiscardPool.RemoveAt(0);
                i++;
            }

            i = 0;
        }
        else
        {
            while (cardsLayoutGroup.transform.childCount < CardCount)
            {
                GameObject card = Instantiate(CardParent, cardsLayoutGroup.transform);

                int randomCard = Random.Range(0, CardPool.Count);
                GameObject cardFace = Instantiate(CardPool[randomCard], GameObject.Find("CardVisuals").transform);

                cardFace.GetComponent<CardFace>().target = card.GetComponentInChildren<Card>().gameObject;


                DiscardPool.Add(CardPool[randomCard]);
                CardPool.Remove(CardPool[randomCard]);
            }

            i = 0;

        }

    }
}
