using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("Sound Clips")]
    public AudioClip buttonClickClip;
    public AudioClip cardSelectSFX;
    public AudioClip cardDeselectSFX;
    public AudioClip cardFlipSFX;
    public AudioClip cardAddSFX;
    public AudioClip spellCastSFX;
    public AudioClip playerHitSFX;
    public AudioClip enemyAttackSFX;
    public AudioClip enemyLockSFX;
    public AudioClip enemyHitSFX;
    public AudioClip playerLoseSFX;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist through scenes
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
        sfxSource.pitch = 1f; // reset pitch
    }

    public void PlayCardDeselect(float pitch = 1f)
    {
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(cardDeselectSFX);
        sfxSource.pitch = 1f;
    }

    public void PlayCardFlip()
    {
        sfxSource.pitch = 1f; // fixed pitch is fine for flip
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
