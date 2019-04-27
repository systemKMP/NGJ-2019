using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Team
{
    TeamA,
    TeamB
}

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }



    private void Awake()
    {
        _instance = this;
    }

    public List<VillagerCharacter> VillagerPrefabs;

    public List<PlayerController> VillagersTeamA;
    public List<PlayerController> VillagersTeamB;

    private int TeamASpawnIndex = 0;
    private int TeamBSpawnIndex = 0;

    public BossCharacter BossPrefab;

    private PlayerController Boss = null;
    private Team BossTeam = Team.TeamA;

    public List<Transform> VillagerSpawnPositonsTeamA;
    public List<Transform> VillagerSpawnPositonsTeamB;
    public Transform BossSpawnPosition;


    public void SetUpPlayer(PlayerController playerController)
    {
        if (VillagersTeamA.Count <= VillagersTeamB.Count)
        {
            if (Boss == null && BossTeam == Team.TeamA)
            {
                playerController.AssignCharacter(BossPrefab, VillagerSpawnPositonsTeamA[TeamASpawnIndex], Team.TeamA);
            }
            else
            {
                playerController.AssignCharacter(VillagerPrefabs[Random.Range(0, VillagerPrefabs.Count)], VillagerSpawnPositonsTeamA[TeamASpawnIndex], Team.TeamA);
            }
            TeamASpawnIndex++;
            if (TeamASpawnIndex >= VillagerSpawnPositonsTeamA.Count)
            {
                TeamASpawnIndex = 0;
            }
            VillagersTeamA.Add(playerController);
        }
        else
        {
            if (Boss == null && BossTeam == Team.TeamB)
            {
                playerController.AssignCharacter(BossPrefab, VillagerSpawnPositonsTeamA[TeamASpawnIndex], Team.TeamA);
            }
            else
            {
                playerController.AssignCharacter(VillagerPrefabs[Random.Range(0, VillagerPrefabs.Count)], VillagerSpawnPositonsTeamB[TeamBSpawnIndex], Team.TeamB);
            }
            TeamBSpawnIndex++;
            if (TeamBSpawnIndex >= VillagerSpawnPositonsTeamB.Count)
            {
                TeamBSpawnIndex = 0;
            }
            VillagersTeamB.Add(playerController);
        }
    }

    public void GetNewCharacter(PlayerController playerController, Team team)
    {
        if (team == Team.TeamA)
        {
            playerController.AssignCharacter(VillagerPrefabs[Random.Range(0, VillagerPrefabs.Count)], VillagerSpawnPositonsTeamA[TeamASpawnIndex], Team.TeamA);
            TeamASpawnIndex++;
            if (TeamASpawnIndex >= VillagerSpawnPositonsTeamA.Count)
            {
                TeamASpawnIndex = 0;
            }
        }
        else
        {
            playerController.AssignCharacter(VillagerPrefabs[Random.Range(0, VillagerPrefabs.Count)], VillagerSpawnPositonsTeamB[TeamBSpawnIndex], Team.TeamB);
            TeamBSpawnIndex++;
            if (TeamBSpawnIndex >= VillagerSpawnPositonsTeamB.Count)
            {
                TeamBSpawnIndex = 0;
            }
        }
    }

    public void BossDeath(Transform bossTrans)
    {
        BossTeam = BossTeam == Team.TeamA ? Team.TeamB : Team.TeamA;

        if (BossTeam == Team.TeamA)
        {
            var player = VillagersTeamA[Random.Range(0, VillagersTeamA.Count)];
            player.Kill(false);
            player.AssignCharacter(BossPrefab, bossTrans, Team.TeamA);
        }
        else
        {
            var player = VillagersTeamB[Random.Range(0, VillagersTeamB.Count)];
            player.Kill(false);
            player.AssignCharacter(BossPrefab, bossTrans, Team.TeamB);
        }
    }
}
