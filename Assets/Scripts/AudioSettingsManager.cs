using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    public static AudioSettingsManager Instance;

    [Header("Volume Control")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioMixer audioMixer;

    private const string volumeKey = "MasterVolume";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 🔁 Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(volumeKey, 1f);
        SetVolume(savedVolume);

        if (volumeSlider != null)
            volumeSlider.value = savedVolume;

        // Auto-link volume slider if it exists in scene
        if (volumeSlider == null)
            TryFindSliderInScene();
    }

    public void OnVolumeSliderChanged(float value)
    {
        SetVolume(value);
        PlayerPrefs.SetFloat(volumeKey, value);
    }

    public void SetVolume(float volume)
    {
        // -80 dB is silence in Audio Mixer
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f);
    }

    private void TryFindSliderInScene()
    {
        volumeSlider = GameObject.FindObjectOfType<Slider>();

        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat(volumeKey, 1f);
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }
    }
}
