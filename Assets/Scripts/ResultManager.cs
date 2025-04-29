using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [Header("Star UI GameObjects")]
    [SerializeField] private GameObject[] stars; // Drag Star1, Star2, Star3 here.

    [Header("Enemies to Track")]
    [SerializeField] private List<HealthBar> enemyHealthBars = new List<HealthBar>();  // Drag all your enemy HealthBars here manually.

    public void CalculateAndShowStars()
    {
        float totalEnemyHealth = 0f;
        float totalDamageDone = 0f;

        foreach (HealthBar enemy in enemyHealthBars)
        {
            float damageTaken = enemy.GetDamageTaken();
            Debug.Log(enemy.gameObject.name + " Damage Taken: " + damageTaken + " / Max Health: " + enemy._maxHealth);

            totalEnemyHealth += enemy._maxHealth;
            totalDamageDone += damageTaken;
        }

        float damagePercentage = (totalDamageDone / totalEnemyHealth) * 100f;
        Debug.Log("TOTAL DAMAGE PERCENTAGE = " + damagePercentage + "%");

        // Hide all stars first
        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }

        // Show stars based on damage done
        if (damagePercentage >= 70f)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            Debug.Log("3 Stars Achieved!");
        }
        else if (damagePercentage >= 50f)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            Debug.Log("2 Stars Achieved!");
        }
        else if (damagePercentage >= 30f)
        {
            stars[0].SetActive(true);
            Debug.Log("1 Star Achieved!");
        }
        else
        {
            Debug.Log("No stars earned.");
        }
    }
}
