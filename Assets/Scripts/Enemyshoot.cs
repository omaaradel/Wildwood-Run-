using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public float currentHealth;

    private Animator anim;
    private AudioManager audioManager;
    private Enemytrap manager;
    private float maxHealth=500;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]  Healthbar healthBar;
    [SerializeField]  GameObject jumpPlatform;
    [SerializeField]  GameObject battleCamera;
    [SerializeField] float bulletSpeed = 10f;


    private void Start()
    {
        anim = GetComponent<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        manager = GameObject.Find("Player").GetComponent<Enemytrap>();
        InvokeRepeating("Shoot", 3f, 3f);
        currentHealth = maxHealth;
        healthBar.updatehealthbar(maxHealth, currentHealth);

    }

    void Shoot()
    {
        if (battleCamera.activeSelf && !manager.isdead)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            audioManager.playSFX(audioManager.enemyShoot);
            anim.SetTrigger("shooting");
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = -firePoint.right * bulletSpeed;

            Destroy(bullet, 4f);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            currentHealth -= 1;
            healthBar.updatehealthbar(maxHealth, currentHealth);
            if (currentHealth <= 0) {
                Destroy(gameObject);
                jumpPlatform.SetActive(true);
                }
        }
    }   
}
