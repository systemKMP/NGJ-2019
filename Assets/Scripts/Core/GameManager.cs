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

    public void BossDeath()
    {
        Debug.Log("Boss dead");
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

    public List<Transform> VillagerSpawnPositonsTeamA;
    public List<Transform> VillagerSpawnPositonsTeamB;

    public void SetUpPlayer(PlayerController playerController)
    {
        if (VillagersTeamA.Count < VillagersTeamB.Count)
        {
            playerController.AssignCharacter(VillagerPrefabs[Random.Range(0, VillagerPrefabs.Count)], VillagerSpawnPositonsTeamA[TeamASpawnIndex], Team.TeamA);
            TeamASpawnIndex++;
            if (TeamASpawnIndex >= VillagerSpawnPositonsTeamA.Count)
            {
                TeamASpawnIndex = 0;
            }
            VillagersTeamA.Add(playerController);
        }
        else
        {
            playerController.AssignCharacter(VillagerPrefabs[Random.Range(0, VillagerPrefabs.Count)], VillagerSpawnPositonsTeamB[TeamBSpawnIndex], Team.TeamB);
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

    void Update()
    {

    }
}
