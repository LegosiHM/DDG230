using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("Sound Clips")]
    [SerializeField] private AudioClip buttonClickClip;
    [SerializeField] private AudioClip cardSelectSFX;
    [SerializeField] private AudioClip cardDeselectSFX;
    [SerializeField] private AudioClip cardFlipSFX;
    [SerializeField] private AudioClip cardAddSFX;
    [SerializeField] private AudioClip spellCastSFX;
    [SerializeField] private AudioClip playerHitSFX;
    [SerializeField] private AudioClip enemyAttackSFX;
    [SerializeField] private AudioClip enemyLockSFX;
    [SerializeField] private AudioClip enemyHitSFX;
    [SerializeField] private AudioClip playerLoseSFX;

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
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayButtonClick()
    {
        PlaySFX(buttonClickClip);
    }

    public void PlayCardSelect(float pitch = 1f)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(cardSelectSFX);
        sfxSource.pitch = 1f;
    }

    public void PlayCardDeselect(float pitch = 1f)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(cardDeselectSFX);
        sfxSource.pitch = 1f;
    }

    public void PlayCardFlip()
    {
        sfxSource.pitch = 1f; 
        sfxSource.PlayOneShot(cardFlipSFX);
    }

    public void PlayCardAdd(float pitch = 1f)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(cardAddSFX);
        sfxSource.pitch = 1f;
    }

    public void PlaySpellCast()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(spellCastSFX);
    }
    public void PlayPlayerHit()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(playerHitSFX);
    }
    public void PlayEnemyAttack()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(enemyAttackSFX);
    }
    public void PlayEnemyLock()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(enemyLockSFX);
    }
    public void PlayEnemyHit()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(enemyHitSFX);
    }
    public void PlayPlayerLose()
    {
        sfxSource.pitch = 1f;
        sfxSource.PlayOneShot(playerLoseSFX);
    }

}
