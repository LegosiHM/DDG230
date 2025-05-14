using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image hpFill; //Assign the HP_Fill Image in the Inspector
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image playerPortrait;
    [SerializeField] public bool isPlayerHealthBar = true;


    private Coroutine flashRoutine;

    public float _maxHealth => maxHealth;

    private float currentHealth;
    public float _currentHealth => currentHealth;


    private CardsManager cardsManager;
    private EnemyManager enemyManager;

    private void Awake()
    {
        cardsManager = Canvas.FindAnyObjectByType<CardsManager>();
        enemyManager = Canvas.FindAnyObjectByType<EnemyManager>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    public void TakeDamage(float damage)
    {
        if (isPlayerHealthBar)
        {
            damage = enemyManager.damage;

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayPlayerHit();
            }

            if (flashRoutine != null)
                StopCoroutine(flashRoutine);

            flashRoutine = StartCoroutine(FlashPortraitRed());

            
        }
        else
        {
            damage = cardsManager.damageResult;

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayEnemyHit();
            }
            
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            if (isPlayerHealthBar)
            {
                if (SoundManager.Instance != null)
                {
                    SoundManager.Instance.PlayPlayerLose();
                }

                Debug.Log("Player Defeated");

                gameManager.LevelCompleted();
            }
            else
            {
                // 💀 Play Death animation
                GetComponent<EnemyAnimationHandler>()?.PlayDeath();

                gameManager.LevelCompleted();
            }
        }
    }



    private void UpdateHealthBar()
    {
        hpFill.fillAmount = currentHealth/maxHealth;
    }

    public float GetDamageTaken()
    {
        return _maxHealth - _currentHealth;
    }
    private IEnumerator FlashPortraitRed()
    {
        if (playerPortrait == null)
            yield break;

        Color originalColor = playerPortrait.color;
        playerPortrait.color = Color.red;

        yield return new WaitForSeconds(0.7f);

        playerPortrait.color = originalColor;
    }
}
