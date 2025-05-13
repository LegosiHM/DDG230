using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float enemyBaseDMG;
    [SerializeField] private List<UnityEvent> enemyMoveset = new List<UnityEvent>();

    [HideInInspector] public int turn = 0;
    [HideInInspector] public float damage;

    [HideInInspector] public int turnWithLockedCard = 1;
    [HideInInspector] public bool HoldLockedCard = false;

    [SerializeField] private GameObject activeEnemy;
    private EnemyAnimationHandler enemyAnim;

    [HideInInspector] public string movesetName;

    private CardsLayoutGroup cardsLayoutGroup;
    private CardsManager cardsManager;
    private CardsPlayedPile cardsPlayedPile;


    private void Awake()
    {
        cardsLayoutGroup = Canvas.FindAnyObjectByType<CardsLayoutGroup>();
        cardsManager = Canvas.FindAnyObjectByType<CardsManager>();
        cardsPlayedPile = Canvas.FindAnyObjectByType<CardsPlayedPile>();
        movesetName = null;
    }
    void Start()
    {
        enemyAnim = activeEnemy.GetComponent<EnemyAnimationHandler>();
    }


    public void TurnAttack()
    {
        damage = 0;
        enemyMoveset[turn-1].Invoke();

        enemyAnim?.PlayHurtThenAttack(0.5f);

        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayEnemyAttack();
        }

        if (HoldLockedCard == true)
        {
            Debug.Log(HoldLockedCard);
            turnWithLockedCard++;
            damage = ((enemyBaseDMG / 2) * turnWithLockedCard);
        }

        if (turn < enemyMoveset.Count)
        {
            turn++;
            return;
        }
        else
        {
            turn = 1;
            return;
        }

    }

    public void Attack()
    {
        damage = enemyBaseDMG + ((enemyBaseDMG/2) * (turn - 1)); //increase DMG by 50% if baseDamage after each turn. (reset when use all movesets)
        //Debug.Log("enemyDMG = " + damage.ToString());
        movesetName = "I cast Abracadabra! Ye just took " +damage+ " damage!";
    }

    public void LockCard()
    {
        if(cardsLayoutGroup.Cards.Count > 0) //check if have cards in hand
        {
            if (cardsPlayedPile.Cards.Count == 0) //check if have no card on cardsPlayedPile
            {
                int randomNumber = Random.Range(0, cardsLayoutGroup.Cards.Count - 1);

                GameObject randomCard = cardsLayoutGroup.Cards[randomNumber];


                randomCard.GetComponent<Card>().IsLockedByEnemy = true;
                randomCard.GetComponent<Card>().MoveCardToPlay();

                enemyAnim?.PlayHurtThenLock(0.5f);

                if (SoundManager.Instance != null)
                {
                    SoundManager.Instance.PlayEnemyLock();
                }

                movesetName = "I cast Alakazam! Ye must use the magic word I selected!";
            }
            else
            {
                movesetName = "Alakazam still take effect! Hahaha!";
            }
        }
        else
        {
            Attack();

            movesetName = "I cast Abracadabra! Ye just took " + damage + " damage!";
        }
    }

    public void LockCardWithDMG()
    {
        if (cardsLayoutGroup.Cards.Count > 0) //check if have cards in hand
        {
            if (cardsPlayedPile.Cards.Count == 0) //check if have no card on cardsPlayedPile
            {
                int randomNumber = Random.Range(0, cardsLayoutGroup.Cards.Count - 1);

                GameObject randomCard = cardsLayoutGroup.Cards[randomNumber];


                randomCard.GetComponent<Card>().IsLockedByEnemy = true;
                randomCard.GetComponent<Card>().MoveCardToPlay();
                HoldLockedCard = true;

                movesetName = "I cast Vivalakazam! Use the magic word I selected OR DIE!";
            }
            else //already hold card
            {
                Debug.Log(turnWithLockedCard.ToString());

                movesetName = "Vivalakazam still take effect! Wahahaha! Ye Dumb Wizard!";
            }
        }
        else //no card on hand
        {
            Attack();

            movesetName = "I cast Abracadabra! Ye just took " + damage + " damage!";
        }
    }

    public void EmptyMove()
    {
        Debug.Log("No Enemy Moveset");
    }
}
