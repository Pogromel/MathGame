using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 0.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingEnemy();
    }
    
    public void MovingEnemy()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bullet"))
        {
          
            Destroy(gameObject);
        }

        if (collision.CompareTag("BottomBarrier"))
        {
            Destroy(gameObject);
        }
    }
}