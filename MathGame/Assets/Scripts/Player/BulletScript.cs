using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 5f;
    public float timeToDestroy = 4f;

    private void Start()
    {
        Invoke("DestroyingBullet", timeToDestroy);
    }

    private void Update()
    {
        MovingBullet();
        
    }

    public void MovingBullet()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    public void DestroyingBullet()
    {
        gameObject.SetActive(false);
    }
}