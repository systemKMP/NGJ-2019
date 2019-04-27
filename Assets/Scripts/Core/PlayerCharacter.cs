using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
    public delegate void CharacterDeath();
    public event CharacterDeath OnCharacterDeath;

    protected bool handleInput = true;

    public ProjectileLauncher MainLauncher;

    public int MaxHealth = 100;
    public int CurrentHealth;

    public Vector3 targetMoveDirection;
    public Vector3 targetFaceDirection;

    public float MaxSpeed = 2.0f;
    public float RotationSpeed = 100.0f;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        if (handleInput)
        {
            gameObject.transform.position += targetMoveDirection * MaxSpeed * Time.deltaTime;
            if (targetFaceDirection.magnitude > 0.1f)
            {
                gameObject.transform.rotation =
                  Quaternion.RotateTowards(gameObject.transform.rotation, Quaternion.LookRotation(targetFaceDirection, Vector3.up), Time.deltaTime * RotationSpeed);
            }
        }
    }

    internal void Hit(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Kill();
        }
    }

    protected virtual void Kill()
    {
        OnCharacterDeath?.Invoke();
        Destroy(gameObject, 2.0f);
        handleInput = false;
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
}
