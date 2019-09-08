using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivateTimer = 3f;
    

    [HideInInspector]
    public bool isEnemyBullet = false;

    void Start()
    {
        if (isEnemyBullet)
        {
            speed *= -1f;
        }
        Invoke("Deactivation", deactivateTimer);
    }

    
    void Update()
    {
        Move();
       
    }

     void Move()
    {
        Vector2 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    void Deactivation()
    {
        ///*gameObject.SetActive(false)*/;
       Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if (target.tag == "Asteroid")
        {
            Destroy(gameObject);
        }
    }
} // class
