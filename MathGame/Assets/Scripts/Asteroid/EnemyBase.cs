using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private List<GameObject> powerUpPrefab;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private AudioSource destroySoundEffect;
    

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
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Bullet"))
        {
            
            Destroy(gameObject);
            destroySoundEffect.Play();

            float randomChance = Random.Range(0f, 1f);
            
            if (randomChance <= 0.25f)
            {
                int randomIndex = Random.Range(0, powerUpPrefab.Count);
                Instantiate(powerUpPrefab[randomIndex], collision.transform.position, Quaternion.identity);
            }
            GameObject explode = Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(explode, 0.75f);
            


        }

        if (collision.CompareTag("BottomBarrier"))
        {
            Debug.Log("Enemy collided");

            PlayerController player = FindObjectOfType<PlayerController>(); 
            if (player != null)
            {
                Debug.Log("Player found");
                player.HandleCollision(gameObject, collision.tag);
            }

            Destroy(gameObject);
            GameObject explode = Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(explode, 0.75f);
        }
        
        if (collision.CompareTag("Player"))
        {
            

            Destroy(gameObject);
            GameObject explode = Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(explode, 0.75f);
        }
        
        
    }
}
