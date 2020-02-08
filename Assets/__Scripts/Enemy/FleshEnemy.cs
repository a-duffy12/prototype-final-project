using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class FleshEnemy : MonoBehaviour
{

    public GameObject enemy; // enemy instance
    public int level = 1; // corresponds to the game level, scales enemy stats accordingly
    public double HPFactor = 1.5; // base for exponential scaling of HP as level number increases
    public double damageFactor = 1.5; // base for exponential scaling of damage as level number increases
    public float range = 3f; // range that enemy can hit player
    public float movementSpeed = 0.5f; // how fast the enemy can move
    public float baseHP = 50; // base hp for enemy
    public float baseDamage = 4; // base damage dealt to player
    public float attackRate = 0.1f; // how fast enemy can attack
    public Transform firePoint; // location of where enemy bullets spawn from

    [HideInInspector]
    public Transform playerTransform; // player location
    [HideInInspector]
    //public Level1EnemySpawner l1ES; // enemy spawn script for level 1
    //public Level2EnemySpawner l2ES; // enemy spawn script for level 2
    //public Level3EnemySpawner l3ES; // enemy spawn script for level 3
    NavMeshAgent agent; // enemy pathfinding agent
    float nextAttackTime = 0; // time until enemy can attack again
    Rigidbody r; 

    // stats after level modification
    private float HP = baseHP*Math.Pow(HPFactor, level-1);
    private float damage = baseDamage*Math.Pow(damageFactor, level-1);

    // Start is called before the first frame update
    void Start() {
    
        agent = GetComponent<NavMeshAgent>(); // gets the level's navmesh
        agent.stoppingDistance = range; // enemy appraoches until it is within attacking distance
        agent.speed = movementSpeed; // how fast enemy travels along the mesh
        r.GetComponent<Rigidbody>(); // gets this enemy's rigidbody
        //r.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
    
        if (agent.remainingDistance - range < 0.01f) { // checks if player is within targeting distance
        
            if (Time.time > nextAttackTime) { // checks if enemy has recently attacked

                nextAttackTime = Time.time + attackRate; // if so, enemy must wait again to attack

                // attack itself
                RaycastHit hit; // creating the hit raycast
                if (Physics.Raycast(firePoint.position, firePoint.forward, out hit)) { // checks if there is a line of sight between the enemy and player

                    if (hit.transform.CompareTag("Player")) { // checks if the line of sight would hit the player

                        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * range, Color.red); // draws a line the length of the enemy range, visible in debug mode
                        IEntity player = hit.transform.GetComponent<IEntity>(); // gets the game object of the player
                        player.ApplyDamage(damage); // applies damage to the player
                    }
                }
            }
        }

        // player tracking (subject to change)
        agent.destination = playerTransform.position; // moves enemy towards palyer
        transform.LookAt(new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.position.z)); // enemy will always face towards the player
        r.velocity *= 0.99f; // reduces rigidbody velocity if forces act on the bullet
    }

    // function to apply damage
    public void ApplyDamage(float damageTaken) {

        HP -= damageTaken; // reduces health by the damage taken
        if(HP <= 0) {

            Destroy(enemy); // destroys the enemy game object

            // reward XP to player
        }
    }
}
