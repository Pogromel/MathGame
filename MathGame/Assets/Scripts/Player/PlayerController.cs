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
    

    private int maxXpos = 6;
    private int maxYpos = 6;

    private int health = 3;
    

    private void Start()
    {
        currentShootingTimer = shootingTimer;
    }

    void Update()
    {
        PlayerMovement();
        Shoot();
        
        
    }

    void PlayerMovement()
    {
        if (Input.GetKeyDown("up") && transform.position.y < maxYpos)
        {
            Vector3 temp = transform.position;
            temp.y += 1f;
            transform.position = temp;
        }
        else if (Input.GetKeyDown("down") && transform.position.y > -maxYpos)
        {
            Vector3 temp = transform.position;
            temp.y -= 1f;
            transform.position = temp;
        }
                
        //Horizontal Movement
        else if (Input.GetKeyDown("right") && transform.position.x < maxXpos)
        {
            Vector3 temp = transform.position;
            temp.x += 1f;
            transform.position = temp;
        }
        else if (Input.GetKeyDown("left") && transform.position.x > -maxXpos)
        {
            Vector3 temp = transform.position;
            temp.x -= 1f;
            transform.position = temp;
        }    
    
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

                Instantiate(shootingBullets, shootingPosition.transform.position, Quaternion.identity);

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

            Destroy(collision.gameObject);        }
    }
}