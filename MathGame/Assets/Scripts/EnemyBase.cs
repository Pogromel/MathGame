using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    [SerializeField] private int moveSpeed = 3;
    public int timeToDestroy = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyingEnemy", timeToDestroy);
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
    
    public void DestroyingEnemy()
    {
        gameObject.SetActive(false);
    }
}
