using UnityEngine;

public class BossCharacter : PlayerCharacter
{
    private Animator animator;

    public AudioClip BossStepClip;
    public AudioClip BossMeleeClip;
    public AudioClip BossDeathClip;
    private AudioSource BossStepSource;
    private AudioSource BossMeleeSource;
    private AudioSource BossDeathSource;

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {
        AudioSource newAudio = gameObject.AddComponent<AudioSource>() as AudioSource;
        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;
        return newAudio;
    }

    public ProjectileLauncher SecondaryLauncher;

    protected override void Awake()
    {
        base.Awake();

        animator = GetComponent<Animator>();

        animator.SetBool("IsWalking", false);
        animator.SetBool("IsStunned", false);

        // Add audio clips
        BossStepSource = AddAudio(BossStepClip, false, true, 0.2f);
        BossMeleeSource = AddAudio(BossMeleeClip, false, true, 0.2f);
        BossDeathSource = AddAudio(BossDeathClip, false, true, 0.2f);
    }

    public override void Kill(bool respawn)
    {
        base.Kill(respawn);

        GameManager.Instance.BossDeath(transform);

        animator.SetBool("IsStunned", true);

        if (!BossDeathSource.isPlaying)
            BossDeathSource.PlayDelayed(0.1f);
        else
            BossDeathSource.Stop();
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
                BossStepSource.PlayDelayed(0.7f);
        }
        else
            BossStepSource.Stop();
    }

    public override void TryStartAction(int actionIndex)
    {
        if (actionIndex == 0)
        {
            if (MainLauncher.TryLaunch(transform.position, transform.rotation))
            {
                SecondaryLauncher.timeRemaining = SecondaryLauncher.launchInterval;
                animator.SetTrigger("Punch");

                if (!BossMeleeSource.isPlaying)
                    BossMeleeSource.PlayDelayed(1.0f);
                else
                    BossMeleeSource.Stop();
            }
        }
        if (actionIndex == 1)
        {
            if (SecondaryLauncher.TryLaunch(transform.position, transform.rotation))
            {
                MainLauncher.timeRemaining = MainLauncher.launchInterval;
                animator.SetTrigger("Punch");

                if (!BossMeleeSource.isPlaying)
                    BossMeleeSource.PlayDelayed(1.0f);
                else
                    BossMeleeSource.Stop();
            }
        }
    }
}
