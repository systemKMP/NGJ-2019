using UnityEngine;

public class BossCharacter : PlayerCharacter
{
    private Animator animator;

    public ProjectileLauncher SecondaryLauncher;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();

        animator.SetBool("IsWalking", false);
        animator.SetBool("IsStunned", false);
    }

    public override void Kill(bool respawn)
    {
        base.Kill(respawn);

        GameManager.Instance.BossDeath(transform);

        animator.SetBool("IsStunned", true);
    }

    public override void TryReleaseAction(int actionIndex)
    {
    }

    public override void TryMove(Vector2 direction)
    {
        base.TryMove(direction);

        animator.SetBool("IsWalking", direction != Vector2.zero);
    }

    public override void TryStartAction(int actionIndex)
    {
        if (actionIndex == 0)
        {
            if (MainLauncher.TryLaunch(transform.position, transform.rotation))
            {
                SecondaryLauncher.timeRemaining = SecondaryLauncher.launchInterval;
                animator.SetTrigger("Punch");
            }
        }
        if (actionIndex == 1)
        {
            if (SecondaryLauncher.TryLaunch(transform.position, transform.rotation))
            {
                MainLauncher.timeRemaining = MainLauncher.launchInterval;
                animator.SetTrigger("Punch");
            }
        }
    }
}
