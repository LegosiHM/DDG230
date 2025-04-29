using UnityEngine;

public class BattleEndButton : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;  // Drag your GameManager here in Inspector

    public void OnEndBattleButtonPressed()
    {
        gameManager.LevelCompleted();
        Debug.Log("End Battle Button Pressed!");
    }
}
