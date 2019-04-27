using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public List<VillagerCharacter> Villagers;
    public List<BossCharacter> Bosses;

    private PlayerController Boss = null;

    public Transform BossSpawnPosition;
    public List<Transform> VillagerSpawnPositons;

    public void SetUpPlayer(PlayerController playerController)
    {
        if (Boss == null)
        {
            playerController.AssignCharacter(Bosses[Random.Range(0, Bosses.Count)], BossSpawnPosition);
            Boss = playerController;
        }
        else
        {
            playerController.AssignCharacter(Villagers[Random.Range(0, Villagers.Count)], VillagerSpawnPositons[Random.Range(0, VillagerSpawnPositons.Count)]);
        }

    }


    void Update()
    {

    }
}
