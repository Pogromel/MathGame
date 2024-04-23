using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float shootingTimer = 0.5f;
    [SerializeField] private GameObject shootingPosition;
    [SerializeField] private GameObject shootingBullets;

    private float currentShootingTimer;
    private bool canShoot;

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