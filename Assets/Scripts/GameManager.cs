using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ResultManager ratingStar;
    [SerializeField] private GameObject resultsPanel;
    private SaveManager saveManager;


    public void Start()
    {
        saveManager = GetComponent<SaveManager>();
    }

    public void LevelCompleted()
    {
        resultsPanel.SetActive(true);
        ratingStar.CalculateAndShowStars();

        if (BGMManager.Instance != null)
        {
            BGMManager.Instance.PlayResultBGM();
        }

        saveManager.SaveData();
        Debug.Log("Gave Saved");
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

    public void GoToNextStage(string NextStage)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(NextStage);
    }
}
