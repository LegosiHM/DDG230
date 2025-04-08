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

                card.GetComponentInChildren<Card>().cardCode = cardFace.GetComponentInChildren<CardFace>().cardCode; //get cardCode from cardFace to card
                

                DiscardPool.Add(CardPool[randomCard]);
                CardPool.Remove(CardPool[randomCard]);
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

}
