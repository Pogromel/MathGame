using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    
    [SerializeField] private GameObject[] shootingPositions; 
    [SerializeField] private GameObject shootingBullets;

    private float currentShootingTimer;
    private bool canShoot;
    public float shootingTimer = 0.25f;
    
    private int health = 3;
    private bool isImmune = false;
    private float immunityDur = 4f;
    
    private int activeShootingPoints = 1;
    

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
                
                for (int i = 0; i < activeShootingPoints; i++)
                {
                    Quaternion flippedRotation = shootingPositions[i].transform.rotation * Quaternion.Euler(0, 0, 180);
                    Instantiate(shootingBullets, shootingPositions[i].transform.position, flippedRotation);
                }
                
                // play sound effects
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bolt"))
        {
            GetComponent<MathQuizController>().StartQuiz(HandleQuizResult);

            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("Shield"))
        {
            GetComponent<MathQuizController>().StartQuiz(HandleQuizResult);
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("Thing"))
        {
            GetComponent<MathQuizController>().StartQuiz(HandleQuizResult);

            Destroy(collision.gameObject);
            
        }
        
        if (collision.CompareTag("Star"))
        {
            GetComponent<MathQuizController>().StartQuiz(HandleQuizResult);

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
    
    private void IncreaseShootingPoints()
    {
        if (activeShootingPoints < shootingPositions.Length)
        {
            activeShootingPoints++;
        }
    }
    
    private void HandleQuizResult(bool success)
    {
        if (success)
        {
            IncreaseShootingPoints(); 
            health += 1; 
            Debug.Log("Power-up applied! Health: " + health + ", Shooting Points: " + activeShootingPoints);
        }
        else
        {
            Debug.Log("Quiz failed or timed out, no power-up applied.");
        }
    }
}