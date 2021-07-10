using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 1000;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laser;
    [SerializeField] GameObject Effect;
    [SerializeField] GameObject hitParticle;
    [SerializeField] float rotateSpeed = 360f;
    [SerializeField] AudioClip[] ricochet;
    [SerializeField] [Range(0,1)]float volume;
    [SerializeField] [Range(0,1)]float deathVolume;
    [SerializeField] AudioClip[] deathSFX;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] [Range(0,1)]float shootVolume = 1f;
    [SerializeField] float projectileSpeed = - 14;




    ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        scoreCounter = FindObjectOfType<ScoreCounter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
        if (tag == "Rotate")
        {
            Rotation();
        }
    }

    private void Rotation()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0) 
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
        
    }

    private void Fire()
    {
        GameObject shootLaser =  Instantiate(laser, transform.position, Quaternion.identity);
        shootLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSFX,Camera.main.transform.position,shootVolume);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if(!damageDealer) { return; }
        ProcessHit(damageDealer);
        //AudioSource.PlayClipAtPoint(ricochet[Random.Range(0, ricochet.Length)], Camera.main.transform.position, volume);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Death();
        }
        GameObject hitEffect = Instantiate(hitParticle, transform.position, transform.rotation);
        Destroy(hitEffect, 1f);

        damageDealer.Hit();
    }

    private void Death()
    {
        Destroy(gameObject);
        GameObject deathExplosion = Instantiate(Effect, transform.position, transform.rotation);
        Destroy(deathExplosion, 1f);
        AudioSource.PlayClipAtPoint(deathSFX[Random.Range(0, deathSFX.Length)], Camera.main.transform.position, deathVolume);
        scoreCounter.AddtoScore();

    }
}
