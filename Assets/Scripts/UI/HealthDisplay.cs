using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private HealthBar healthBar;
    [SerializeField] private Text healthChanceDisplay;

    private void Awake()
    {
        healthBar = GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        healthChanceDisplay.text = healthBar._currentHealth.ToString() + " / " + healthBar._maxHealth.ToString();
    }
}