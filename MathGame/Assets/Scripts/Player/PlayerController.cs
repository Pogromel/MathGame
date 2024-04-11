using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed = 5f; //Remove when implementing vertices type movement.


    [SerializeField] private float shooting_Timer = 0.5f;
    [SerializeField] private GameObject shooting_Position;
    [SerializeField] private GameObject shooting_Bullets;



    private float current_Shooting_Timer;
    private bool canShoot;
    
    private float y_min, y_max;
                                //Those 2 Are boundries for X AND Y position. 
    private float x_min, x_max;


    private void Start()
    {
        current_Shooting_Timer = shooting_Timer;
    }

    void Update()
    {
        PlayerMovement();
        Shoot();
    }

    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 temp = transform.position;

        if (horizontalInput != 0f)
        {
            temp.x += horizontalInput * speed * Time.deltaTime;               //All of this can be scraped when creating vertices type movement
            temp.x = Mathf.Clamp(temp.x, x_min, x_max);
        }

        if (verticalInput != 0f)
        {
            temp.y += verticalInput * speed * Time.deltaTime;
            temp.y = Mathf.Clamp(temp.y, y_min, y_max);
        }

        transform.position = temp;
    }

    void Shoot()
    {
        shooting_Timer += Time.deltaTime;
        if (shooting_Timer > current_Shooting_Timer)
        {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canShoot)
            {
                canShoot = false;
                shooting_Timer = 0f;
            
                Instantiate(shooting_Bullets, shooting_Position.transform.position, Quaternion.identity);
            
                //play sound effects
            }
        }
    }

    
    
}
