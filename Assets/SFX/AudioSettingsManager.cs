using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettingsManager : MonoBehaviour
{
    public static AudioSettingsManager Instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider volumeSlider;

    private const string volumePrefKey = "MasterVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Subscribe to scene load to re-link slider
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(volumePrefKey, 100f);
        SetVolume(savedVolume);

        // If slider exists now, initialize it
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        // Try to find a new slider in the new scene
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.FindObjectOfType<Slider>();
            if (volumeSlider != null)
            {
                float savedVolume = PlayerPrefs.GetFloat(volumePrefKey, 100f);
                volumeSlider.value = savedVolume;
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }
    }

    public void SetVolume(float value)
    {
        float normalized = Mathf.Clamp(value / 100f, 0.0001f, 1f);
        float volumeInDB = Mathf.Log10(normalized) * 20f;

        audioMixer.SetFloat("MasterVolume", volumeInDB);
        PlayerPrefs.SetFloat(volumePrefKey, value);
    }

    public void TryLinkSlider()
    {
        if (volumeSlider != null) return; // Already linked

        // 🧠 true = include inactive objects
        Slider found = GameObject.FindObjectOfType<Slider>(true);
        if (found != null && found.gameObject.name.ToLower().Contains("volume"))
        {
            volumeSlider = found;
            float savedVolume = PlayerPrefs.GetFloat(volumePrefKey, 100f);
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

}
