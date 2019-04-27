using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

public class PlayerController : MonoBehaviour
{
    public PlayerCharacter Character;

    private readonly IDictionary<Team, bool[]> availableMembers = new Dictionary<Team, bool[]>
    {
        { Team.TeamA, new bool[4] },
        { Team.TeamB, new bool[4] },
    };

    private Team playerTeam;

    [UsedImplicitly]
    private void Start()
    {
        GameManager.Instance.SetUpPlayer(gameObject.GetComponent<PlayerController>());
    }

    void OnMovement(InputValue value)
    {
        Character.TryMove(value.Get<Vector2>());
    }

    void OnFace(InputValue value)
    {
        Character.TryFace(value.Get<Vector2>());
    }

    void OnActionA(InputValue value)
    {
        Character.TryStartAction(0);
    }

    void OnActionB(InputValue value)
    {
        Character.TryStartAction(1);
    }

    void OnActionC(InputValue value)
    {
        Character.TryStartAction(2);
    }

    public void AssignCharacter(PlayerCharacter characterPrefab, Transform spawnTrans, Team team)
    {
        playerTeam = team;
        Character = Instantiate(characterPrefab, spawnTrans.position, spawnTrans.rotation);
        Character.OnCharacterDeath += HandleDeath;

        Character.gameObject.layer = playerTeam == Team.TeamA ? 8 : 9;

        var numberInTeam = Array.FindIndex(availableMembers[playerTeam], x => x == false);

        Debug.Log("Assigning player index " + numberInTeam + " for team " + team);

        Character.Team = playerTeam;
        Character.NumberInTeam = numberInTeam;
        Character.SetupIndicator();

        availableMembers[playerTeam][numberInTeam] = true;
    }

    private void HandleDeath(bool respawn)
    {
        availableMembers[Character.Team][Character.NumberInTeam] = false;
        Character.OnCharacterDeath -= HandleDeath;
        if (respawn)
        {
            GameManager.Instance.GetNewCharacter(gameObject.GetComponent<PlayerController>(), playerTeam);
        }
    }

    public void Kill(bool respawn = true)
    {
        Character.Kill(respawn);
    }
}
