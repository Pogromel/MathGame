using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

<<<<<<< Updated upstream
    [SerializeField] public float speed = 5f;
    [SerializeField] private float y_min, y_max;
    [SerializeField] private float x_min, x_max;
    
  
=======
    [SerializeField] public float speed = 5f; //Remove when implementing vertices type movement.
    [SerializeField] private float shooting_Timer = 0.5f;
    [SerializeField] private GameObject shooting_Position;
    [SerializeField] private GameObject shooting_Bullets;



    private float current_Shooting_Timer;
    private bool canShoot;

    //Those 2 Are boundries for X AND Y position
    private int maxXpos = 6;
    private int maxYpos = 6;
                                


    private void Start()
    {
        current_Shooting_Timer = shooting_Timer;
    }

>>>>>>> Stashed changes
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
<<<<<<< Updated upstream
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 temp = transform.position;

        if (horizontalInput != 0f)
        {
            temp.x += horizontalInput * speed * Time.deltaTime;
            temp.x = Mathf.Clamp(temp.x, x_min, x_max);
        }

        if (verticalInput != 0f)
        {
            temp.y += verticalInput * speed * Time.deltaTime;
            temp.y = Mathf.Clamp(temp.y, y_min, y_max);
        }

        transform.position = temp;
    }
    
    
=======

        //Vertical Movement
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
>>>>>>> Stashed changes
}
