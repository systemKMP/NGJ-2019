using System;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;
using UnityEngine.Experimental.Input.Plugins.Users;

public class PlayerController : MonoBehaviour
{
    public PlayerCharacter Character;
    private Team playerTeam;

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
        if (playerTeam == Team.TeamA)
        {
            Character.gameObject.layer = 8;
        } else
        {
            Character.gameObject.layer = 9;
        }
    }

    private void HandleDeath(bool respawn)
    {
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
