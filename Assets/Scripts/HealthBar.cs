using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image hpFill; //Assign the HP_Fill Image in the Inspector
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private GameManager gameManager;

    public float _maxHealth;

    private float currentHealth;
    public float _currentHealth;


    private CardsManager cardsManager;
    private EnemyManager enemyManager;

    private void Awake()
    {
        cardsManager = Canvas.FindAnyObjectByType<CardsManager>();
        enemyManager = Canvas.FindAnyObjectByType<EnemyManager>();
    }

    private void Start()
    {
        _maxHealth = maxHealth;

        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        _currentHealth = currentHealth;
        if(_currentHealth <= 0)
        {
            gameManager.LevelCompleted();
        }

    }

    public void TakeDamage(float damage)
    {
        if (gameObject.transform.name.Contains("Player"))
        {
            damage = enemyManager.damage;

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayPlayerHit();
            }

            //Debug.Log("playerTakeDMG"+ "damage = " + enemyManager.damage + " Turn = " + enemyManager.turn);
        }
        if (gameObject.transform.name.Contains("Enemy"))
        {
            //Debug.Log("enemyTakeDMG: " + cardsManager.damageResult);
            damage = cardsManager.damageResult;

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayEnemyHit();
            }

        }
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        //Debug.Log(currentHealth);

        UpdateHealthBar();

        if (currentHealth <= 0 && gameObject.transform.name.Contains("Player"))
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlayPlayerLose();
            }

            // Optional: trigger defeat UI or logic here
            Debug.Log("Player Defeated");
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
}
