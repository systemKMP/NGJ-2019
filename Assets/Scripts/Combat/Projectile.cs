using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public int Damage;

    public float Lifetime;
    private float timePassed;

    public float Velocity;

    private bool isActive = true;

    public Team FromTeam;

    void Update()
    {
        transform.position += transform.rotation * Vector3.forward * Velocity * Time.deltaTime;

        timePassed += Time.deltaTime;
        if (timePassed > Lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!isActive)
        {
            return;
        }

        string tag = col.tag;
        if ((FromTeam == Team.TeamA && col.gameObject.layer == 9) || (FromTeam == Team.TeamB && col.gameObject.layer == 8))
        {
            Destroy(gameObject, 1.0f);
            isActive = false;
            col.gameObject.GetComponent<PlayerCharacter>().Hit(Damage);
        }
    }
}
