using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlipChanceDisplay : MonoBehaviour
{
   private CardsManager cardsManager;
   private Text flipChanceDisplay;

    private void Awake()
    {
        flipChanceDisplay = GetComponent<Text>();
        cardsManager = Canvas.FindAnyObjectByType<CardsManager>();
    }

    void Update()
    {
        flipChanceDisplay.text = cardsManager.flipChance.ToString();
    }
}
