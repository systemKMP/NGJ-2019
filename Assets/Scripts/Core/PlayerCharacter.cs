using System;
using UnityEngine;
using UnityEngine.Assertions;
using Debug = UnityEngine.Debug;

public abstract class PlayerCharacter : MonoBehaviour
{
    public delegate void CharacterDeath(bool respawn);
    public event CharacterDeath OnCharacterDeath;

    protected bool handleInput = true;

    public ProjectileLauncher MainLauncher;

    public int MaxHealth = 100;
    public int CurrentHealth;

    public Vector3 targetMoveDirection;
    public Vector3 targetFaceDirection;

    public float MaxSpeed = 2.0f;
    public float RotationSpeed = 100.0f;

    public Team Team;
    public int NumberInTeam;

    private bool isDead = false;

    private Rigidbody body;

    protected virtual void Awake()
    {
        CurrentHealth = MaxHealth;
        body = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (handleInput)
        {
            body.velocity = targetMoveDirection * MaxSpeed;
            body.angularVelocity = Vector3.zero;
            if (targetFaceDirection.magnitude > 0.1f)
            {
                gameObject.transform.rotation =
                  Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(targetFaceDirection, Vector3.up), Time.deltaTime * RotationSpeed);
            }
        }
        else
        {
            body.velocity = Vector3.zero;
        }
    }

    internal void Hit(int damage)
    {
        if (isDead)
        {
            return;
        }
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Kill(true);
        }
    }

    public virtual void Kill(bool respawn)
    {
        isDead = true;
        OnCharacterDeath?.Invoke(respawn);
        Destroy(gameObject, 2.0f);
        handleInput = false;
        body.isKinematic = true;
    }

    public virtual void TryMove(Vector2 direction)
    {
        if (handleInput)
        {
            targetMoveDirection = new Vector3(direction.x, 0.0f, direction.y);
        }
    }

    public virtual void TryFace(Vector2 direction)
    {
        if (handleInput)
        {
            if (direction.magnitude > 0.2f)
            {
                targetFaceDirection = new Vector3(direction.x, 0.0f, direction.y);
            }
            else
            {
                targetFaceDirection = transform.rotation * Vector3.forward;
            }
        }
    }

    public abstract void TryStartAction(int actionIndex);
    public abstract void TryReleaseAction(int actionIndex);

    public void SetupIndicator()
    {
        var indicatorContainer = transform.GetChild(0);

        Assert.IsNotNull(indicatorContainer, "indicatorContainer != null");

        var indicator = indicatorContainer.GetChild(Team == Team.TeamA ? 0 : 1).GetChild(NumberInTeam);

        indicator.gameObject.SetActive(true);
    }
}
