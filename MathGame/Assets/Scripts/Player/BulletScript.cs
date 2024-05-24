using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed = 5f;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("TopBarrier"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

    }
}