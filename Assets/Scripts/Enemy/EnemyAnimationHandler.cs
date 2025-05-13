using UnityEngine;
using System.Collections;

public class EnemyAnimationHandler : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void PlayHurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void PlayDeath()
    {
        animator.SetTrigger("Die");
    }

    public void PlayHurtThenAttack(float delay = 0.5f)
    {
        StartCoroutine(HurtThenAttack(delay));
    }

    private IEnumerator HurtThenAttack(float delay)
    {
        animator.ResetTrigger("Attack");  // Avoid pre-triggered attack
        animator.SetTrigger("Hurt");
        SoundManager.Instance?.PlayEnemyHit();

        yield return new WaitForSeconds(delay);

        animator.SetTrigger("Attack");
        SoundManager.Instance?.PlayEnemyAttack();
    }
    public void PlayHurtThenLock(float delay = 0.5f)
    {
        StartCoroutine(HurtThenLock(delay));
    }

    private IEnumerator HurtThenLock(float delay)
    {
        animator.ResetTrigger("Lock");
        animator.SetTrigger("Hurt");

        SoundManager.Instance?.PlayEnemyHit();

        yield return new WaitForSeconds(delay);

        animator.SetTrigger("Lock");
        SoundManager.Instance?.PlayEnemyLock();
    }

    public void PlayLock()
    {
        animator.SetTrigger("Lock");
    }


}
