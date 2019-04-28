using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCharacter : PlayerCharacter
{
    public Team OwnerTeam;

    public override void Kill(bool respawn)
    {
        transform.GetChild(0).GetComponentInChildren<Wall>().Hit();
        GameManager.Instance.DeclareVictory(OwnerTeam == Team.TeamA ? Team.TeamB : Team.TeamA);
    }

    public override void TryReleaseAction(int actionIndex)
    {
        throw new System.NotImplementedException();
    }

    public override void TryStartAction(int actionIndex)
    {
        throw new System.NotImplementedException();
    }
}
