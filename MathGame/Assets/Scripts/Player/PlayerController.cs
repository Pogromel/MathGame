using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        
        //Vertical Movement
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;

            if (temp.y > y_max)
                temp.y = y_max;
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;

            if (temp.y < y_min)
                temp.y = y_min;
            
            transform.position = temp;
        }
        
        //Horizontal Movement
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x < x_max)
                temp.x = x_max;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < x_min)
                temp.x = x_min;

            transform.position = temp;
        }
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
