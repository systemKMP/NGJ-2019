using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCharacter : PlayerCharacter
{
    public override void Kill(bool respawn)
    {
        base.Kill(respawn);
        GameManager.Instance.BossDeath(transform);
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
