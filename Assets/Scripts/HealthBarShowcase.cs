using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarShowcase : MonoBehaviour
{
    HealthBar mainHealthBar;
    private float showcaseHealth;
    [SerializeField] private CardsManager cardsManager;
    [SerializeField] private Image hpFill;

    void Start()
    {
        mainHealthBar = GetComponent<HealthBar>();

        showcaseHealth = mainHealthBar._currentHealth;

    }

    void Update()
    {
        DamageShowcase();
    }

    public void DamageShowcase()
    {
        float damage;

        damage = cardsManager.damageResult;
        showcaseHealth = mainHealthBar._currentHealth - damage;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        hpFill.fillAmount = showcaseHealth / mainHealthBar._maxHealth;
    }
}
