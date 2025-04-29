using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ResultManager ratingStar;  // Drag the RatingStar object here
    [SerializeField] private GameObject resultsPanel; // Drag the ResultsPanel here

    public void LevelCompleted()
    {
        resultsPanel.SetActive(true); // Show the results panel
        ratingStar.CalculateAndShowStars(); // Calculate damage and show stars
    }
}
