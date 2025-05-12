using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSFX : MonoBehaviour
{
    private void Awake()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayButtonClick();
        }
    }
}
