using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerCharacter : PlayerCharacter
{

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
}
