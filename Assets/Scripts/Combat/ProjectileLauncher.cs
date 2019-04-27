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
        var go = Instantiate(ProjectilePrefab, position, direction);
        go.FromTeam = gameObject.layer == 8 ? Team.TeamA : Team.TeamB;
        go.gameObject.layer = gameObject.layer + 2;
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;
    }
}
