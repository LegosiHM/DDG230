using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ResultManager ratingStar;  // Drag the RatingStar object here
    [SerializeField] private GameObject resultsPanel; // Drag the ResultsPanel here

    public void LevelCompleted()
    {
        resultsPanel.SetActive(true);
        ratingStar.CalculateAndShowStars();

        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.PlayResultBGM();
        }
    }

}
