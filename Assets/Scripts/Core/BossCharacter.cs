using UnityEngine;

public class BossCharacter : PlayerCharacter
{
    private Animator animator;

    public AudioClip BossStepClip;
    private AudioSource BossStepSource;

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();

        animator.SetBool("IsWalking", false);
        animator.SetBool("IsStunned", false);

        // Add audio clips
        BossStepSource = AddAudio(BossStepClip, false, true, 0.2f);
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

        if (direction.magnitude > 0.05f)
        {
            if (!BossStepSource.isPlaying)
                BossStepSource.Play();
        }
        else
            BossStepSource.Stop();
    }

    public override void TryStartAction(int actionIndex)
    {
        if (actionIndex == 0)
        {
            MainLauncher.TryLaunch(transform.position, transform.rotation);

            animator.SetTrigger("Punch");
        }
    }
}
