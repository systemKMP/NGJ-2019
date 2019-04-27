using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public float launchInterval = 2.0f;
    public float timeRemaining = 0.0f;

    public float launchDelay;

    public Projectile ProjectilePrefab;

    public void TryLaunch(Vector3 position, Quaternion direction)
    {
        if (timeRemaining <= 0.0f)
        {
            StartCoroutine(LauchProjectile(position, direction));
        }
    }

    private IEnumerator LauchProjectile(Vector3 position, Quaternion direction)
    {
        yield return new WaitForSeconds(launchDelay);
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
