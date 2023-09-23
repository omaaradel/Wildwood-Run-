using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public Transform firePoint; 
    public GameObject bulletPrefab; 
    public float bulletSpeed = 10f; 
     
    private Animator anim;
    private bool shooting;
    private float maxHealth=300;
    private float currentHealth ;
    
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private GameObject jumpplatform;
    [SerializeField] private GameObject battlecamera;
    [SerializeField] private AudioSource shootsound;


    private void Start()
    {
        anim = GetComponent<Animator>();
        shooting = false;
        InvokeRepeating("Shoot", 3f, 3f);
        currentHealth = maxHealth;
        healthbar.updatehealthbar(maxHealth, currentHealth);

    }

    void Shoot()
    {
        if (battlecamera.activeSelf)
        {

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            shootsound.Play();
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
            healthbar.updatehealthbar(maxHealth, currentHealth);
            if (currentHealth <= 0) {
                Destroy(gameObject);
                jumpplatform.SetActive(true);
                }
        }
    }   
}
