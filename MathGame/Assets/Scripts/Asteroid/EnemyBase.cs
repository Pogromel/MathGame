using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public ScoreUIScript scoreScript;
    [SerializeField] private float moveSpeed = 0.4f;
    [SerializeField] private List<GameObject> powerUpPrefab;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private AudioSource destroySoundEffectPrefab;

    private void Awake()
    {
        if (scoreScript == null)
        {
            scoreScript = FindObjectOfType<ScoreUIScript>();
        }
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
            if (destroySoundEffectPrefab != null)
            {
                AudioSource destroySound = Instantiate(destroySoundEffectPrefab, transform.position, Quaternion.identity);
                destroySound.Play();
                Destroy(destroySound.gameObject, destroySound.clip.length);
            }
            
            Destroy(gameObject);
            if (scoreScript != null)
            {
                scoreScript.incrementScoreByDamage();
            }
            else
            {
                Debug.LogError("Score Script is not assigned!");
            }

            float randomChance = Random.Range(0f, 1f);
            if (randomChance <= 0.28f)
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
