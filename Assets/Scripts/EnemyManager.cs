using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float enemyBaseDMG;
    [SerializeField] private List<UnityEvent> enemyMoveset = new List<UnityEvent>();

    [HideInInspector] public int turn = 1;
    [HideInInspector] public float damage;

    public void TurnAttack()
    {
        enemyMoveset[turn-1].Invoke();

        if(turn < enemyMoveset.Count)
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
    }

    public void PlaceCard()
    {
        Debug.Log("I placecard");
    }

    public void Debuff()
    {
        Debug.Log("I debuff");
    }
}
