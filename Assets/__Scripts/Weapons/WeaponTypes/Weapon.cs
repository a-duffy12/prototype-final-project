﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Weapon : MonoBehaviour
{

    public GameObject bulletType; // bullet prefab object, different types of bullet exist
    public Transform firePoint; // where the bullets come from
<<<<<<< HEAD
    public int ammoType = 0; // 0 is pistol, 1 is plasma, 2 is rail, 3 is emp
    public bool singleFire = false; // is the weapon automatic or semi-automatic
    public float fireRate = 0.1f; // how long in between each bullet is fired
    public int currentMagSize = 30; // how many bullets per magazine
    public float reloadTime = 3.0f; // how long to reload
    public float damage = 15; // how much damage per bullet
    public int range = 100; // how far can the gun shoot
=======
    public int ammoType; // 0 is pistol, 1 is plasma, 2 is rail, 3 is emp
    public bool singleFire; // is the weapon automatic or semi-automatic
    public float fireRate; // how long in between each bullet is fired
    public int magSize; // how many bullets per magazine
    public float reloadTime; // how long to reload
    public float damage; // how much damage per bullet
    public int range; // how far can the gun shoot
>>>>>>> combat-Aiden
    //public AudioClip bulletAudio; // audio for bullet fires
    //public AudioClip plasmaAudio; // audio for plasma fires
    //public AudioClip railAudio; // audio for rail fires
    //public AudioClip empAudio; // audio for emp fires
    //public AudioClip reloadAudio; // aduio for reload

    [HideInInspector]
    public Inventory manager; // instantiate a weapon manager

<<<<<<< HEAD
    private float nextFireTime = 0; // how long until the next bullet is fired
    private bool hasAmmo = true; // whether or not the mag has ammo left
    private int magSize = 0; 
    //AudioSource source;
=======
    private float _nextFireTime = 0; // how long until the next bullet is fired
    private bool _hasAmmo = true; // whether or not the mag has ammo left
    private int _currentMagSize = 0; 
    //AudioSource _source;
>>>>>>> combat-Aiden

    // Start is called before the first frame update
    void Start() {
    
<<<<<<< HEAD
        magSize = currentMagSize; // sets base magazine size to the magazine size
        //source = GetComponent<AudioSource>(); // gets the audio
        //source.playOnAwake = false; // does not play on startup
        //source.spatialBlend = 1f; // makes the sound 3D
=======
        _currentMagSize = magSize; // sets base magazine size to the magazine size
        //_source = GetComponent<AudioSource>(); // gets the audio
        //_source.playOnAwake = false; // does not play on startup
        //_source.spatialBlend = 1f; // makes the sound 3D
>>>>>>> combat-Aiden
    }

    // Update is called once per frame
    void Update() {
    
        // semi-auto firing
        if (Input.GetMouseButtonDown(0) && singleFire) { // mouse button down returns true when mouse button is released

            Fire(); // shoots weapon
        } 
        
        // auto firing
        if (Input.GetMouseButton(0) && !singleFire) { // mouse button returns true as long as the button is held down

            Fire(); // fires weapon
        }

        // reload
        if (Input.GetKeyDown(KeyCode.R) && hasAmmo) { // R to reload

            StartCoroutine(Reload()); // reloads weapon
        }
    }

    // function to fire a weapon
    void Fire() {

        if (hasAmmo) { // if the weapon has ammo

            if (Time.time > nextFireTime) { // if the weapon has waited long enough to fire

                nextFireTime = Time.time + fireRate; //once firing, update the time to the next time gun is allowed to fire
            
                if (_currentMagSize > 0) {

                    // set the firepoint location to the camera's center, extending the length of the weapon's range
                    Vector3 firePointPosition = manager.playerCamera.transform.position + manager.playerCamera.transform.forward * range;
                    RaycastHit hit; // create a raycast to track hits

                    // checks if there is a line of sight to shoot (should basically always be true)
                    if (Physics.Raycast(manager.playerCamera.transform.position, manager.playerCamera.transform.forward, out hit, range)) {
                        
                        firePointPosition = hit.point; // moves firepoint to where the raycast can hit
                    }

                    firePoint.LookAt(firePointPosition); // moves actual firepoint to where the bullet should go

                    // firing bullet projectile
                    if (ammoType == 0) {

                        GameObject bulletObject = Instantiate(bulletType, firePoint.position, firePoint.rotation);
                        Bullet bullet = bulletObject.GetComponent<Bullet>(); // gets an instance of the bullet object
                        bullet.SetDamage(damage); // sets the damage based of the weapon
<<<<<<< HEAD
                        currentMagSize--; // removes a bullet from the magazine
                        //source.clip = bulletAudio; // sets firing audio
                        //source.Play(); // plays firing audio
=======
                        _currentMagSize--; // removes a bullet from the magazine
                        //_source.clip = bulletAudio; // sets firing audio
                        //_source.Play(); // plays firing audio
>>>>>>> combat-Aiden

                    } else if (ammoType == 1) {

                        GameObject bulletObject = Instantiate(bulletType, firePoint.position, firePoint.rotation);
                        Plasma plasmaBullet = bulletObject.GetComponent<Plasma>(); // gets an instance of the bullet object
                        plasmaBullet.SetDamage(damage); // sets the damage based of the weapon
<<<<<<< HEAD
                        currentMagSize--; // removes a bullet from the magazine
                        //source.clip = plasmaAudio; // sets firing audio
                        //source.Play(); // plays firing audio
=======
                        _currentMagSize--; // removes a bullet from the magazine
                        //_source.clip = plasmaAudio; // sets firing audio
                        //_source.Play(); // plays firing audio
>>>>>>> combat-Aiden

                    } else if (ammoType == 2) {

                        GameObject bulletObject = Instantiate(bulletType, firePoint.position, firePoint.rotation);
                        Rail railBullet = bulletObject.GetComponent<Rail>(); // gets an instance of the bullet object
                        railBullet.SetDamage(damage); // sets the damage based of the weapon
<<<<<<< HEAD
                        currentMagSize--; // removes a bullet from the magazine
                        //source.clip = railAudio; // sets firing audio
                        //source.Play(); // plays firing audio
=======
                        _currentMagSize--; // removes a bullet from the magazine
                        //_source.clip = railAudio; // sets firing audio
                        //_source.Play(); // plays firing audio
>>>>>>> combat-Aiden

                    } else if (ammoType == 3) {

                        GameObject bulletObject = Instantiate(bulletType, firePoint.position, firePoint.rotation);
                        Emp empBullet = bulletObject.GetComponent<Emp>(); // gets an instance of the bullet object
                        empBullet.SetDamage(damage); // sets the damage based of the weapon
<<<<<<< HEAD
                        currentMagSize--; // removes a bullet from the magazine
                        //source.clip = empAudio; // sets firing audio
                        //source.Play(); // plays firing audio
=======
                        _currentMagSize--; // removes a bullet from the magazine
                        //_source.clip = empAudio; // sets firing audio
                        //_source.Play(); // plays firing audio
>>>>>>> combat-Aiden
                    }
                    
                } else { // no bullets left

                    // could have it reload, instead play a message saying to reload
                    // automatic reloads are waste
<<<<<<< HEAD
                    hasAmmo = false; //prevents weapon from firing   
=======
                    //prevents weapon from firing   
>>>>>>> combat-Aiden
                }          
            }
        }
    }

    // ienum to reload weapon
    IEnumerator Reload() {

        hasAmmo = false; // prevents gun from being fired mid reload

        //source.clip = reloadAudio; // sets reload audio
        // source.Play(); // plays reload audio

        yield return new WaitForSeconds(reloadTime); // how long to wait for reload

        if (_currentMagSize > 0) { // reload with one in the chamber

<<<<<<< HEAD
            currentMagSize = magSize + 1;
        
        } else { // reload with none in the chamber

            currentMagSize = magSize;
=======
            _currentMagSize = magSize + 1;
        
        } else { // reload with none in the chamber

            _currentMagSize = magSize;
>>>>>>> combat-Aiden
        } 

        hasAmmo = true; // allows gun to fire again post reload
    }


    // function to make player hold active weapon, deal with weapon switching
    public void ActivateWeapon(bool activate) {

        StopAllCoroutines(); // cancels reload to switch weapons
        hasAmmo = true; // lets weapons fire, as new weapon amy have ammo
        gameObject.SetActive(activate); // activates the weapon
    }

}
