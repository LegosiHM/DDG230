using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class DamageDisplay : MonoBehaviour
{
    private CardsManager cardsManager;
    [SerializeField] private Text damageDisplay;
    private int damage;
    private int damageMult;
    private int damageResult;

    void Start()
    {
        cardsManager = GetComponent<CardsManager>();
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
