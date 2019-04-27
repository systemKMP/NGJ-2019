using UnityEngine;

public class VillagerCharacter : PlayerCharacter
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("IsRunning", false);
    }

    protected override void Kill()
    {
        base.Kill();

        animator.SetBool("IsDead", true);
    }

    public override void TryMove(Vector2 movement)
    {
        base.TryMove(movement);

        animator.SetBool("IsRunning", movement != Vector2.zero);
    }

    public override void TryReleaseAction(int actionIndex)
    {
    }

    public override void TryStartAction(int actionIndex)
    {
        if (actionIndex == 0)
        {
            MainLauncher.TryLaunch(transform.position, transform.rotation);
        }
    }
}
