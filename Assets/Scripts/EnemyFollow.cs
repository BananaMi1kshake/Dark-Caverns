using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 2f; // the speed at which the enemy moves
    public float stopDistance = 1f; // the distance at which the enemy stops moving

    void Update()
    {
        // find the player game object with the "Player" tag
        GameObject player = GameObject.FindWithTag("Player");

        // if the player game object was found
        if (player != null)
        {
            // if the distance between the enemy and the player is greater than the stop distance
            if (Vector3.Distance(transform.position, player.transform.position) > stopDistance)
            {
                // move towards the player
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
