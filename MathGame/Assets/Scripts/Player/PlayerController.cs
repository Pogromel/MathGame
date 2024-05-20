using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    [SerializeField] private GameObject shootingPosition;
    [SerializeField] private GameObject shootingPositionTwo;
    [SerializeField] private GameObject shootingBullets;

    private float currentShootingTimer;
    private bool canShoot;
    private bool SecoungShootingPointActive = false;
    public float shootingTimer = 0.25f;
    
    private int health = 3;
    private bool isImmune = false;
    private float immunityDur = 4f;
    

    private void Start()
    {
        currentShootingTimer = shootingTimer;
    }

    void Update()
    {
        Shoot();
    }

    
    void Shoot()
    {
        shootingTimer += Time.deltaTime;
        if (shootingTimer > currentShootingTimer)
        {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                shootingTimer = 0f;

                Quaternion flippedRotation = shootingPosition.transform.rotation * Quaternion.Euler(0, 0, 180);
                Instantiate(shootingBullets, shootingPosition.transform.position, flippedRotation);

                if (SecoungShootingPointActive)
                {
                    Instantiate(shootingBullets, shootingPositionTwo.transform.position, Quaternion.identity);
                }
                // play sound effects
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bolt"))
        {
            health += 1;

            Destroy(collision.gameObject);        }
        if (collision.CompareTag("Shield"))
        {
            health += 1;

            Destroy(collision.gameObject);        }
        if (collision.CompareTag("Thing"))
        {
            

            Destroy(collision.gameObject);

            SecoungShootingPointActive = true;
        }
        if (collision.CompareTag("Star"))
        {
            health += 1;

            Destroy(collision.gameObject);
            
        }
        if (collision.CompareTag("Enemy") && !isImmune)
        {
            health -= 1;
            Debug.Log("Hit by Enemy Health: " + health);
            StartCoroutine(ActivateImmunity());

            if (health <= 0)
            {
                Die();
            }
        }
        if (collision.CompareTag("BottomBarrier") && !isImmune)
        {
            TakeDamage(1);
        }
        
    }

    private IEnumerator ActivateImmunity()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityDur);
        isImmune = false;
    }

    public void Die()
    {
        Debug.Log("Player Died");
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            health -= damage;
            Debug.Log("Player took damage Health: " + health);
            StartCoroutine(ActivateImmunity());

            if (health <= 0)
            {
                Die();
            }
        }
    }
    public void HandleCollision(GameObject other, string tag)
    {
        if (tag == "BottomBarrier")
        {
            TakeDamage(1);
        }
    }
}