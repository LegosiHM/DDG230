using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [Header("Star UI GameObjects")]
    [SerializeField] private GameObject[] stars; // Drag Star1, Star2, Star3 here.

    [Header("Player to Track")]
    [SerializeField] private HealthBar playerHealthBar;

    [Header("Enemies to Track")]
    [SerializeField] private List<HealthBar> enemyHealthBars = new List<HealthBar>();  // Drag all your enemy HealthBars here manually.

    [Header("Star Sounds")]

    [SerializeField] private AudioClip star1SFX;
    [SerializeField] private AudioClip star2SFX;
    [SerializeField] private AudioClip star3SFX;

    public void CalculateAndShowStars()
    {
        float totalEnemyHealth = 0f;
        float totalDamageDone = 0f;

        foreach (HealthBar enemy in enemyHealthBars)
        {
            float damageTaken = enemy.GetDamageTaken();
            Debug.Log(enemy.gameObject.name + " Damage Taken: " + damageTaken + " / Max Health: " + enemy._maxHealth);

            totalEnemyHealth = enemy._maxHealth;
            totalDamageDone = damageTaken;
        }

        float damagePercentage = (totalDamageDone / totalEnemyHealth) * 100f;
        Debug.Log("TOTAL DAMAGE PERCENTAGE = " + damagePercentage + "%");

        // Hide all stars first
        foreach (GameObject star in stars)
        {
            star.SetActive(false);
        }

        // Show stars based on damage done
        if (damagePercentage >= 90f)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            SoundManager.Instance.sfxSource.PlayOneShot(star3SFX);
            Debug.Log("3 Stars Achieved!");
            CollectStageStar(3);
        }
        else if (damagePercentage >= 50f)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            SoundManager.Instance.sfxSource.PlayOneShot(star2SFX);
            Debug.Log("2 Stars Achieved!");
            CollectStageStar(2);
        }
        else if (damagePercentage >= 30f)
        {
            stars[0].SetActive(true);
            SoundManager.Instance.sfxSource.PlayOneShot(star1SFX);
            Debug.Log("1 Star Achieved!");
            CollectStageStar(1);
        }
        else
        {
            Debug.Log("No stars earned.");
            CollectStageStar(0);
        }
    }

    private void CollectStageStar(int StarEarn)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Stage1")
        {
            if(ResultCollection.Stage1Star <  StarEarn)
            {
                ResultCollection.Stage1Star = StarEarn;
            }

            ResultCollection.Stage2Unlocked = true;
        }
        else if (currentScene == "Stage2")
        {
            if (ResultCollection.Stage2Star < StarEarn)
            {
                ResultCollection.Stage2Star = StarEarn;
            }

            ResultCollection.Stage3Unlocked = true;
        }
        else if (currentScene == "Stage3")
        {
            if (ResultCollection.Stage3Star < StarEarn)
            {
                ResultCollection.Stage3Star = StarEarn;
            }
        }
    }

    
}
