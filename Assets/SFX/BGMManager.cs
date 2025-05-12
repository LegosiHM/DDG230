using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioClip mainMenuBGM;
    [SerializeField] private AudioClip combatBGM;
    [SerializeField] private AudioClip resultBGM;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // 🔄 Listen to scene loads
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string sceneName = scene.name;

        if (sceneName == "MainMenu" || sceneName == "StageSelect")
        {
            PlayMainMenuBGM();
        }
        else if (sceneName == "Stage1" || sceneName == "Stage2" || sceneName == "Stage3" || sceneName == "SampleScene")
        {
            PlayCombatBGM();
        }
    }

    public void PlayMainMenuBGM()
    {
        if (bgmSource.clip == mainMenuBGM && bgmSource.isPlaying) return;

        bgmSource.clip = mainMenuBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayCombatBGM()
    {
        if (bgmSource.clip == combatBGM && bgmSource.isPlaying) return;

        bgmSource.clip = combatBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayResultBGM()
    {
        if (bgmSource.clip == resultBGM && bgmSource.isPlaying) return;

        bgmSource.clip = resultBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 🧼 Clean up
    }
}
