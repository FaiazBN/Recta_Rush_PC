using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [Header("Player")] 
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float downPadding = 1.5f;
    [SerializeField] float health = 200f;
    [SerializeField] Transform player;
    //[SerializeField] float backWardForce = -100f;
    [SerializeField] GameObject Effect;
    [SerializeField] GameObject hitParticle;
    [SerializeField] float recoil = -20f;
    [Header("Player Bullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] AudioClip Goddamn;
    [SerializeField] float projectileSpeed = 14f;
    [SerializeField] float firingPeriod = 0.05f;
    [SerializeField] Transform shootPosition;
    [SerializeField] [Range(0,1)] float sfxVolume = 0.5f;
    Vector2 direction;



    Coroutine continuouslyShoot;

    //
    float xMin;
    float xMax;   
    float yMin;
    float yMax;

    //
    AudioSource myAudio;
    Rigidbody2D rb;
    HealthBar healthbar;


    void Start()
    {
        MoveBoundaries();
        rb = GetComponent<Rigidbody2D>();
        myAudio = GetComponent<AudioSource>();
        rb.velocity = new Vector2(0f,17f);
        healthbar = FindObjectOfType<HealthBar>();
        healthbar.SetMaxHealth(health);
    }


    void Update()
    {
        Move();
        Fire();
        //RotateWithMouse();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            continuouslyShoot = StartCoroutine(Shootingcontinuously());
 
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(continuouslyShoot);
        }
        
    }
    public float ReturnPlayerHealth()
    {
        return health;
    }


    private IEnumerator Shootingcontinuously()
    {
        while (true)
        {
            GameObject bulletShoot = Instantiate(bullet, shootPosition.transform.position, Quaternion.identity) as GameObject;

            bulletShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            //bulletShoot.GetComponent<Rigidbody2D>().AddForce(bulletShoot.transform.up *projectileSpeed);
            //myAudio.PlayOneShot(Goddamn);
            AudioSource.PlayClipAtPoint(Goddamn, Camera.main.transform.position, sfxVolume);
            //rb.AddForce(new Vector2(0, backWardForce));
            rb.velocity = new Vector2(0f,recoil);
            yield return new WaitForSeconds(firingPeriod);
        }

    }

    private void Move()
    {
        var deltaX = Input.GetAxisRaw("Horizontal") * -1;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX * Time.deltaTime * playerSpeed,xMin,xMax);

        var deltaY = Input.GetAxisRaw("Vertical");
        var newYPos = Mathf.Clamp(transform.position.y + deltaY * Time.deltaTime * playerSpeed,yMin,yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
    private void MoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding; ////VTWP coverst camera min (0) and max(1) to world units. .x because we just want to know the x value.
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + downPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        PlayerHitProcess(damageDealer);
    }

    private void PlayerHitProcess(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        healthbar.SetHealth(health);
        if (health <= 0)
        {
            Death();
        }
        GameObject hitEffect = Instantiate(hitParticle,transform.position,transform.rotation);
        Destroy(hitEffect, 1f);
        damageDealer.Hit();
    }

    private void Death()
    {
        Destroy(gameObject);
        GameObject deathExplosion = Instantiate(Effect, transform.position, transform.rotation);
        Destroy(deathExplosion, 1f);
    }

    private void RotateWithMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)player.position;
        player.transform.right = direction;
    }

}
