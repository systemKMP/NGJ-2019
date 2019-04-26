using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : PlayerCharacter
{
    protected override void Kill()
    {
        GameManager.Instance.BossDeath();
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
