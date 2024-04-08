using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed = 5f;
    [SerializeField] private float y_min, y_max;
    [SerializeField] private float x_min, x_max;
    
  
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
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
    
    
}
