using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public float launchInterval = 2.0f;
    public float timeRemaining = 0.0f;

    public Projectile ProjectilePrefab;

    public void TryLaunch(Vector3 position, Quaternion direction)
    {
        if (timeRemaining <= 0.0f)
        {
            LauchProjectile(position, direction);
        }
    }

    private void LauchProjectile(Vector3 position, Quaternion direction)
    {
        timeRemaining = launchInterval;
        Instantiate(ProjectilePrefab, position, direction);
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
    }
}
