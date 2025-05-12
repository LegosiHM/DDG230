using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ResultManager ratingStar;
    [SerializeField] private GameObject resultsPanel;

    public void LevelCompleted()
    {
        resultsPanel.SetActive(true);
        ratingStar.CalculateAndShowStars();

        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.PlayResultBGM();
        }
    }

    public void RetryLevel()
    {
        if (resultsPanel != null)
            resultsPanel.SetActive(false);

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStageSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageSelect"); // Ensure the scene name matches exactly
    }

    public void GoToNextStage()
    {
        Time.timeScale = 1f;

        // Replace this with your actual next scene logic
        string current = SceneManager.GetActiveScene().name;

        if (current == "Stage1") SceneManager.LoadScene("Stage2");
        else if (current == "Stage2") SceneManager.LoadScene("Stage3");
        else SceneManager.LoadScene("StageSelect"); // Fallback
    }
}
