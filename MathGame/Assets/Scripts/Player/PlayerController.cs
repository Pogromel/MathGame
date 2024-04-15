using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float shootingTimer = 0.5f;
    [SerializeField] private GameObject shootingPosition;
    [SerializeField] private GameObject shootingBullets;

    private float currentShootingTimer;
    private bool canShoot;

    private int maxXpos = 6;
    private int maxYpos = 6;

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
        currentShootingTimer += Time.deltaTime;
        if (currentShootingTimer > shootingTimer)
        {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                currentShootingTimer = 0f;

                Instantiate(shootingBullets, shootingPosition.transform.position, Quaternion.identity);

                // play sound effects
            }
        }
    }
}