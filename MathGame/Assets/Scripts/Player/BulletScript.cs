using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeToDestroy = 100f;

    private void Start()
    {
        Invoke("DestroyingBullet", timeToDestroy);
    }

    private void Update()
    {
        MovingBullet();
        DestroyingBullet();
    }

    public void MovingBullet()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    public void DestroyingBullet()
    {
        Destroy(gameObject);
    }
}