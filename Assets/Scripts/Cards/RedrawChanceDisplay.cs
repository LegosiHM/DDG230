using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RedrawChanceDisplay : MonoBehaviour
{
    private CardsManager cardsManager;
    private Text redrawChanceDisplay;

    private void Awake()
    {
        redrawChanceDisplay = GetComponent<Text>();
        cardsManager = Canvas.FindAnyObjectByType<CardsManager>();
    }

    void Update()
    {
        redrawChanceDisplay.text = cardsManager.redrawChance.ToString();
    }
}
