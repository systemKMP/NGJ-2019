using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
public class VillagerCharacter : PlayerCharacter
{
    private Animator animator;

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

    public override void TryMove(Vector2 direction)
    {
        base.TryMove(direction);

        animator.SetBool("IsRunning", direction != Vector2.zero);
    }

    public void Die() => animator.SetBool("IsDead", true);

    public void Respawn() => animator.SetBool("IsDead", false);

    [UsedImplicitly]
    private void Awake() => animator = GetComponent<Animator>();
}
