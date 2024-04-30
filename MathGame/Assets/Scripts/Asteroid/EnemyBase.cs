using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private List<GameObject> powerUpPrefab;

    

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

            float randomChance = Random.Range(0f, 1f);
            
            if (randomChance <= 0.25f)
            {
                int randomIndex = Random.Range(0, powerUpPrefab.Count);
                Instantiate(powerUpPrefab[randomIndex], collision.transform.position, Quaternion.identity);
            }
           


        }

        if (collision.CompareTag("BottomBarrier"))
        {
            Destroy(gameObject);
        }
    }
}
