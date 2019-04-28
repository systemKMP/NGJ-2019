using JetBrains.Annotations;
using UnityEngine;

[UsedImplicitly]
public class VillagerCharacter : PlayerCharacter
{
    private Animator animator;

    public AudioClip VillagerAttackClip;
    private AudioSource VillagerAttackSource;

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    [SerializeField]
    private Material TeamAMaterial;

    [SerializeField]
    private Material TeamBMaterial;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();
        animator.SetBool("IsRunning", false);

        // Add audio clips
        VillagerAttackSource = AddAudio(VillagerAttackClip, false, true, 0.2f);
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
                if (!VillagerAttackSource.isPlaying)
                    VillagerAttackSource.PlayDelayed(0.1f);
                else
                    VillagerAttackSource.Stop();
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
