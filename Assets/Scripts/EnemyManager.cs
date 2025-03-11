using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int turn = 1;
    public float damage;

    public void TurnAttack()
    {
        if(turn == 1)
        {
            damage = 3f;
            turn++;
            return; 
        }

        if (turn == 2)
        {
            damage = 4f;
            turn++;
            return;

        }

        if (turn == 3)
        {
            damage = 5f;
            turn = 1;
            return;

        }

    }
}
