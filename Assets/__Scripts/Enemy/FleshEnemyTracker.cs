/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshEnemyTracker : MonoBehaviour
{
    public GameObject player; // player object
    public GameObject thisEnemy; // enemy object
    public float targetDistance; // distance enemy is away from the player
    public float range = 10; // enemy attack range allowed
    public float movementSpeed; // enemy movement speed
    public int attackTrigger; // not sure
    public RaycastHit shot; // tracking enemy weapon fires

    // called every frame
    void Update() {
        
        transform.LookAt(player.transform); // enemy turns to face player

        // checks if enemy is facing the player 
        if (Physics.RayCast(transform.position, transform.TransformDirection(vector3.forward), out shot)) {

            targetDistance = shot.distance; // sets the distance of targetting to distance between player and enemy
            if (targetDistance <= range) { // checks if player is within enemy's target range
                Enemy = 0.02f;
            }
        
        }

    }



}*/
