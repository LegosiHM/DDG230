using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image hpFill; //Assign the HP_Fill Image in the Inspector
    public float maxHealth = 100f;
    private float currentHealth;


    public CardsManager cardsManager;
    public EnemyManager enemyManager;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        if (gameObject.transform.name.Contains("Player"))
        {
            damage = enemyManager.damage;
            Debug.Log("playerTakeDMG"+ "damage = " + enemyManager.damage + " Turn = " + enemyManager.turn);
        }
        if (gameObject.transform.name.Contains("Enemy"))
        {
            Debug.Log("enemyTakeDMG");
            damage = cardsManager.damage;
        }
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //Debug.Log(currentHealth);

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        hpFill.fillAmount = currentHealth/maxHealth;
    }
}
