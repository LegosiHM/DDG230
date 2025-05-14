using UnityEngine;
using System.Collections;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator animator;
    private string AttackTrigger = "Attack";
    private string HurtTrigger = "Hurt";
    private string LockTrigger = "Lock";
    private string DieTrigger = "Die";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        animator.SetTrigger(AttackTrigger);
    }

    public void PlayHurt()
    {
        animator.SetTrigger(HurtTrigger);
    }

    public void PlayDeath()
    {
        animator.SetTrigger(DieTrigger);
    }

    public void PlayHurtThenAttack(float delay = 0.5f)
    {
        StartCoroutine(HurtThenAttack(delay));
    }

    private IEnumerator HurtThenAttack(float delay)
    {
        animator.ResetTrigger(AttackTrigger);  // Avoid pre-triggered attack
        animator.SetTrigger(HurtTrigger);
        SoundManager.Instance?.PlayEnemyHit();

        yield return new WaitForSeconds(delay);

        animator.SetTrigger(AttackTrigger);
        SoundManager.Instance?.PlayEnemyAttack();
    }
    public void PlayHurtThenLock(float delay = 0.5f)
    {
        StartCoroutine(HurtThenLock(delay));
    }

    private IEnumerator HurtThenLock(float delay)
    {
        animator.ResetTrigger(LockTrigger);
        animator.SetTrigger(HurtTrigger);

        SoundManager.Instance?.PlayEnemyHit();

        yield return new WaitForSeconds(delay);

        animator.SetTrigger(LockTrigger);
        SoundManager.Instance?.PlayEnemyLock();
    }

    public void PlayLock()
    {
        animator.SetTrigger(LockTrigger);
    }


}
