using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DamageDisplay : MonoBehaviour
{
    private CardsManager cardsManager;
    private Text damageDisplay;
    private int damage;
    private int damageMult;
    private int damageResult;

    private void Awake()
    {
        damageDisplay = GetComponent<Text>();
        cardsManager = Canvas.FindAnyObjectByType<CardsManager>();
    }

    void Update()
    {
        damage = cardsManager.damage;
        damageMult = cardsManager.damageMult;
        damageResult = cardsManager.damageResult;

        if (damageResult == 0)
        {
            damageDisplay.text = null;
        }
        else
        {
            damageDisplay.text = damage.ToString() + " x " + damageMult.ToString() + " = " + damageResult.ToString();
        }
    }
}
