using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovesetDisplay : MonoBehaviour
{
    private EnemyManager enemyManager;
    [SerializeField] private Text movesetDisplay;

    private void Awake()
    {
        enemyManager = Canvas.FindAnyObjectByType<EnemyManager>();
    }

    void Update()
    {
        movesetDisplay.text = enemyManager.movesetName;
    }
}
