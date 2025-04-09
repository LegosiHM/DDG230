using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public GameObject SelectedCard;
    public GameObject HoveringMenu;

    public CardsLayoutGroup cardsLayoutGroup;
    public CardsPlayedPile cardsPlayedPile;
    public CardsDiscard cardsDiscardBox;


    public GameObject CardParent;
    public List<GameObject> CardPool = new List<GameObject>();
    public List<GameObject> DiscardPool = new List<GameObject>();

    public GameObject CardVisualLayout;

    [SerializeField] private int CardCount = 4;
    int i = 0;
    int fullCardPool;

    int count = 0;

    private int _damage;
    public int damage;

    private int _damageMult;
    public int damageMult;

    private int _damageResult;
    public int damageResult;


    private void Start()
    {
        fullCardPool = CardPool.Count;
        AddCard();

        
    }

    private void Update()
    {
        CalculateDMG();
        damage = _damage;
        damageMult = _damageMult;
        damageResult = _damageResult;

        ResetPool();
    }

    public void AddCard()
    {
        
            while (cardsLayoutGroup.transform.childCount < CardCount)
            {
                GameObject card = Instantiate(CardParent, cardsLayoutGroup.transform);
                

                int randomCard = Random.Range(0, CardPool.Count);

                GameObject cardFace = Instantiate(CardPool[randomCard], CardVisualLayout.transform);

                cardFace.GetComponent<CardFace>().target = card.GetComponentInChildren<Card>().gameObject;

                card.GetComponentInChildren<Card>().cardCode = cardFace.GetComponentInChildren<CardFace>().cardCode; //get cardCode from cardFace to card
                

                DiscardPool.Add(CardPool[randomCard]);
                CardPool.Remove(CardPool[randomCard]);
            }

            i = 0;

        
    }

    public void ResetPool()
    {
        if (CardPool.Count < CardCount - cardsLayoutGroup.transform.childCount) //if pool < empty hand
        {
            while (i < fullCardPool && DiscardPool.Count > 0) //reset pool
            {
                CardPool.Add(DiscardPool[0]);
                DiscardPool.RemoveAt(0);
                i++;
            }

            i = 0;
        }
    }

    public void CalculateDMG()
    {
        count = 0;
        _damage = 0;
        _damageMult = 1;
        _damageResult = 0;

        foreach (GameObject cardObject in cardsPlayedPile.Cards)
        {
            Card card = cardObject.GetComponent<Card>();
            string cardCode = card.cardCode;

            if (count == 0)
            {
                _damage += cardCode.Count();
                count++;
            }
            else
            {
                _damage += cardCode.Count() - 1;
                _damageMult++;
            }
        }

        _damageResult = _damage * _damageMult;
    }




    public void PlayCard()
    {
        foreach (GameObject cardObject in cardsPlayedPile.Cards)
        {
            Card card = cardObject.GetComponent<Card>();

            card.transform.parent.SetParent(cardsDiscardBox.transform);

            card.transform.position = cardsDiscardBox.transform.position;
        }

        cardsPlayedPile.Cards.Clear();
    }

    public void FlipCard()
    {

        //Flip Visual
        foreach (GameObject cardObject in cardsLayoutGroup.Cards)
        {
            foreach(Transform cardFace in CardVisualLayout.transform)
            {
                if (cardFace.GetComponent<CardFace>().target == cardObject)
                {
                    Vector3 cardTransformScale = cardFace.transform.localScale;
                    cardTransformScale.x *= -1;
                    cardFace.transform.localScale = cardTransformScale;
                }
            }
        }


        foreach (GameObject cardObject in cardsLayoutGroup.Cards)
        {
            Card card = cardObject.GetComponentInChildren<Card>();
            char firstCode = card.cardCode[0];
            char LastCode = card.cardCode[card.cardCode.Length - 1];

            char newFirstCode = LastCode;
            char newLastCode = firstCode;

            if (card.cardCode.Length > 2)
            {
                string betweenCode = card.cardCode.Substring(1, card.cardCode.Length - 2);

                

                card.cardCode = newFirstCode.ToString() + betweenCode.ToString() + newLastCode.ToString();
            }
            else
            {
                card.cardCode = newFirstCode.ToString() + newLastCode.ToString();
            }
        }
            /*
        foreach (Card cardObject in cardsLayoutGroup.transform)
        {
            char firstCode = cardObject.cardCode[0];
            char LastCode = cardObject.cardCode[cardObject.cardCode.Length];
            string betweenCode = cardObject.cardCode.Substring(1,cardObject.cardCode.Length-1);

            char newFirstCode = LastCode;
            char newLastCode = firstCode;

            cardObject.cardCode = newFirstCode + betweenCode + newLastCode;
        }*/
    }


}
