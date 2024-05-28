using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    [SerializeField] private GameObject[] shootingPositions; 
    [SerializeField] private GameObject shootingBullets;
    [SerializeField] private ParticleSystem shootingEffect;
    [SerializeField] private HealthBarUi healthBarUi;
    [SerializeField] private AudioSource shootingAudioSource;

    private float currentShootingTimer;
    private bool canShoot;
    public float shootingTimer = 0.25f;
    
    public int health = 3;
    private bool isImmune = false;
    private float immunityDur = 4f;
    
    private int activeShootingPoints = 1;
    private Coroutine shootingPointsResetCoroutine;

    private void Start()
    {
        currentShootingTimer = shootingTimer;
        UpdateHealthBar();
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canShoot)
            {
                canShoot = false;
                shootingTimer = 0f;
                
                for (int i = 0; i < activeShootingPoints; i++)
                {
                    Quaternion flippedRotation = shootingPositions[i].transform.rotation * Quaternion.Euler(0, 0, 180);
                    Instantiate(shootingBullets, shootingPositions[i].transform.position, flippedRotation);
                }
                
                shootingAudioSource.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shield"))
        {
            GetComponent<MathQuizController>().StartQuiz(HandleShieldQuizResult);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Thing"))
        {
            GetComponent<MathQuizController>().StartQuiz(HandleThingQuizResult);
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("Enemy") && !isImmune)
        {
            health -= 1;
            Debug.Log("Hit by Enemy Health: " + health);
            StartCoroutine(ActivateImmunity());

            if (health <= 0)
            {
                UpdateHealthBar();
                Die();
            }
            else
            {
                UpdateHealthBar();
            }
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
            else
            {
                UpdateHealthBar();
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
    
    private void IncreaseShootingPoints()
    {
        if (activeShootingPoints < shootingPositions.Length)
        {
            activeShootingPoints++;
            ResetShootingPointsTimer();
        }
    }
    private void ResetShootingPointsTimer()
    {
        if (shootingPointsResetCoroutine != null)
        {
            StopCoroutine(shootingPointsResetCoroutine);
        }
        shootingPointsResetCoroutine = StartCoroutine(ResetShootingPoints());
    }

    private IEnumerator ResetShootingPoints()
    {
        yield return new WaitForSeconds(20f);
        activeShootingPoints = 1;
    }
    
    private void HandleShieldQuizResult(bool success)
    {
        if (success)
        {
            health = Mathf.Min(health + 1, 6); 
            Debug.Log("Shield power-up applied! Health: " + health);
            UpdateHealthBar();
        }
        else
        {
            Debug.Log("Quiz failed or timed out, no shield power-up applied.");
        }
    }

    private void HandleThingQuizResult(bool success)
    {
        if (success)
        {
            IncreaseShootingPoints();
            Debug.Log("Thing power-up applied! Shooting Points: " + activeShootingPoints);
        }
        else
        {
            Debug.Log("Quiz failed or timed out, no thing power-up applied.");
        }
    }
    private void UpdateHealthBar()
    {
        float healthPercentage = (float)health / 6; 
        healthBarUi.UpdateHealth(healthPercentage);
    }
    
    
    
}