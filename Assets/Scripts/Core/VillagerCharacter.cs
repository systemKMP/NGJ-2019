using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
public class VillagerCharacter : PlayerCharacter
{
    private Animator animator;

    [SerializeField]
    private Material TeamAMaterial;

    [SerializeField]
    private Material TeamBMaterial;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        animator.SetBool("IsRunning", false);
    }

    public override void Kill(bool respawn)
    {
        base.Kill(respawn);
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
        if (handleInput)
        {
            if (actionIndex == 0)
            {
                MainLauncher.TryLaunch(transform.position, transform.rotation);
            }
        }
    }

    public override void SetupTeamColor()
    {
        var child = transform.GetChild(2);

        var materials = child.GetComponent<SkinnedMeshRenderer>().materials;
        var newMaterials = new[]
                               {
                                   materials[0], materials[1],
                                   (Team == Team.TeamA ? TeamAMaterial : TeamBMaterial)
                               };

        child.GetComponent<SkinnedMeshRenderer>().materials = newMaterials;
    }
}
