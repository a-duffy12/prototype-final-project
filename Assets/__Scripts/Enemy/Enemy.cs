using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

//[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]

public class Enemy : MonoBehaviour
{
    // default values for a generic enemy 
    public int level; // corresponds to the game level, scales enemy stats accordingly
    public double hpFactor; // base for exponential scaling of HP as level number increases
    public double damageFactor; // base for exponential scaling of damage as level number increases
    public double xpFactor; // base for exponential scaling of xp rewards as level number increases
    public float range; // range that enemy can hit player
    public float movementSpeed; // how fast the enemy can move
    public float baseHP; // base hp for enemy
    public float baseDamage; // base damage dealt to player
    public float attackRate; // how fast enemy can attack
    public int baseXP; // how much XP is given to the player upon killing the enemy
    public Transform firePoint; // location of where enemy bullets spawn from

    [HideInInspector]
    public Transform playerTransform; // player location
    [HideInInspector]
    /*public Level1EnemySpawner l1ES; // enemy spawn script for level 1
    public Level2EnemySpawner l2ES; // enemy spawn script for level 2
    public Level3EnemySpawner l3ES; // enemy spawn script for level 3
    private NavMeshAgent _agent; // enemy pathfinding agent */
    //private float _nextAttackTime = 0; // time until enemy can attack again
    //private Rigidbody _r; 

    // enemy properties after modifiers
    private float _hp;
    private float _damage;
    private float _xp;

    // Start is called before the first frame update
    void Start() {
    
        /*_agent = GetComponent<NavMeshAgent>(); // gets the level's navmesh
        _agent.stoppingDistance = range; // enemy appraoches until it is within attacking distance
        _agent.speed = movementSpeed; // how fast enemy travels along the mesh
        _r.GetComponent<Rigidbody>(); // gets this enemy's rigidbody
        r.useGravity = false; */
        _hp = baseHP*(float)Math.Pow(hpFactor, level-1); // set HP
        _damage = baseDamage*(float)Math.Pow(damageFactor, level-1); // set damage
        _xp = baseXP*(float)Math.Pow(xpFactor, level-1); // set xp reward
    }

    // Update is called once per frame
    /* void Update() {
    
        if (_agent.remainingDistance - range < 0.01f) { // checks if player is within targeting distance
        
            if (Time.time > _nextAttackTime) { // checks if enemy has recently attacked

                _nextAttackTime = Time.time + attackRate; // if so, enemy must wait again to attack

                // attack itself
                RaycastHit hit; // creating the hit raycast
                if (Physics.Raycast(firePoint.position, firePoint.forward, out hit)) { // checks if there is a line of sight between the enemy and player

                    if (hit.transform.CompareTag("Player")) { // checks if the line of sight would hit the player

                        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * range, Color.red); // draws a line the length of the enemy range, visible in debug mode
                        IEntity player = hit.transform.GetComponent<IEntity>(); // gets the game object of the player
                        player.ApplyDamage(_damage); // applies damage to the player
                    }
                }
            }
        }

        // player tracking (subject to change)
        _agent.destination = playerTransform.position; // moves enemy towards palyer
        transform.LookAt(new Vector3(playerTransform.transform.position.x, transform.position.y, playerTransform.position.z)); // enemy will always face towards the player
        _r.velocity *= 0.99f; // reduces rigidbody velocity if forces act on the bullet
    } */

    // function to apply damage
    public void ApplyDamage(float damageTaken) {

        _hp -= damageTaken; // reduces health by the damage taken
        if(_hp <= 0) {

            Destroy(this); 

            // reward XP to player
        }
    }
}
