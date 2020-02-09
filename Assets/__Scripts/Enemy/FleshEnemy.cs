using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshEnemy : Enemy
{
    // constructor
    public FleshEnemy() {
        // default values for a generic enemy 
        level = 1; // corresponds to the game level, scales enemy stats accordingly
        hpFactor = 1.5; // base for exponential scaling of HP as level number increases
        damageFactor = 1.5; // base for exponential scaling of damage as level number increases
        xpFactor = 1.5; // base for exponential scaling of xp rewards as level number increases
        range = 20f; // range that enemy can hit player
        movementSpeed = 5f; // how fast the enemy can move
        baseHP = 50f; // base hp for enemy
        baseDamage = 10f; // base damage dealt to player
        attackRate = 0.5f; // how fast enemy can attack
        baseXP = 100; // how much XP is given to the player upon killing the enemy
    }
}
