using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [HideInInspector] public GameObject SelectedCard;
    [HideInInspector] public GameObject HoveringMenu;


    public CardsLayoutGroup cardsLayoutGroup;
    public CardsPlayedPile cardsPlayedPile;
    public CardsDiscard cardsDiscardBox;

    private EnemyManager enemyManager;

    [HideInInspector]
    public GameObject CardParent;

    [SerializeField] private List<GameObject> CardPool = new List<GameObject>();
    [SerializeField] private List<GameObject> DiscardPool = new List<GameObject>();

    [HideInInspector] public GameObject CardVisualLayout;

    [SerializeField] private int _maxCardOnHand = 4;
    [SerializeField] private int _flipChance = 5;
    [HideInInspector] public int flipChance => _flipChance;
    
    [SerializeField] private int _redrawChance = 5;
    [HideInInspector] public int redrawChance => _redrawChance;

    private int i = 0;
    private int fullCardPool => CardPool.Count;

    private int count = 0;

    private int _damage;
    [HideInInspector] public int damage => _damage;

    private int _damageMult;
    [HideInInspector] public int damageMult => _damageMult;

    private int _damageResult;
    [HideInInspector] public int damageResult => _damageResult;


    private void Start()
    {
        enemyManager = Canvas.FindAnyObjectByType<EnemyManager>();

        AddCard();
    }

    private void Update()
    {
        CalculateDMG();
    }

    public void DrawCard()
    {
        if(CardPool.Count <= _maxCardOnHand - cardsLayoutGroup.transform.childCount)
        {
            ResetPool();
            AddCard();
        }
        else
        {
            AddCard();
        }
    }

    public void AddCard()
    {
            while (cardsLayoutGroup.transform.childCount < _maxCardOnHand)
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
            while (i < fullCardPool && DiscardPool.Count > 0) //reset pool
            {
                //Debug.Log("ResetPool");
                CardPool.Add(DiscardPool[0]);
                DiscardPool.RemoveAt(0);
                i++;
            }

            i = 0;
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
        if(cardsPlayedPile.Cards.Count > 0)
        {
            if(cardsPlayedPile.Cards.Count > 1) //more than 1 card played
            {
                foreach (GameObject cardObject in cardsPlayedPile.Cards)
                {
                    enemyManager.turnWithLockedCard = 0;
                    enemyManager.HoldLockedCard = false;
                    MoveCardToDiscard(cardObject);
                }

                cardsPlayedPile.Cards.Clear();
            }
            else if (cardsPlayedPile.Cards.Count == 1) //only 1 card played
            {
                /*
                    foreach (GameObject cardObject in cardsPlayedPile.Cards)
                    {
                        if (cardObject.GetComponent<Card>().IsLockedByEnemy == false) //not locked by enemy
                        {
                            MoveCardToDiscard(cardObject);
                            cardsPlayedPile.Cards.Clear();
                        }
                        else //locked by enemy
                        {
                            Debug.Log("LockedCard");
                        }
                    }

                */
                if (cardsPlayedPile.Cards[0].GetComponent<Card>().IsLockedByEnemy == false) //not locked by enemy
                {
                    MoveCardToDiscard(cardsPlayedPile.Cards[0]);
                    cardsPlayedPile.Cards.Clear();
                }
                else //locked by enemy
                {
                    Debug.Log("LockedCard");
                }

            }
        }
        else
        {
            Debug.Log("No Card Played");
        }
    }

    public void FlipCard()
    {

        if(_flipChance > 0)
        {
            //Flip Visual
            foreach (GameObject cardObject in cardsLayoutGroup.Cards)
            {
                foreach (Transform cardFace in CardVisualLayout.transform)
                {
                    if (cardFace.GetComponent<CardFace>().target == cardObject)
                    {
                        Vector3 cardTransformScale = cardFace.transform.localScale;
                        cardTransformScale.x *= -1;
                        cardFace.transform.localScale = cardTransformScale;
                    }
                }
            }

            //Flip Code
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

            _flipChance--;
        }
        else
        {
            Debug.Log("No flip chance left");
        }
    }

    public void RedrawCard()
    {
        if(_redrawChance > 0)
        {
            foreach (GameObject cardObject in cardsLayoutGroup.Cards)
            {
                MoveCardToDiscard(cardObject);
            }
            cardsLayoutGroup.Cards.Clear();
            DrawCard();

            _redrawChance--;
        }
        else
        {
            Debug.Log("No redraw chance left");
        }
    }

    public void MoveCardToDiscard(GameObject cardObject)
    {
        Card card = cardObject.GetComponent<Card>();

        card.Played = false;
        card.transform.parent.SetParent(cardsDiscardBox.transform);
        card.transform.position = cardsDiscardBox.transform.position;
    }

}
