using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void LoadScene(string selectedScene)
    {
        SceneManager.LoadScene(selectedScene);
    }
}
