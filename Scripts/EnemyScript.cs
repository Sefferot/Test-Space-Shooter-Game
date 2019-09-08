using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 50f;

    public int scoreValue;
    
    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float boundY = -5.80f;

    public Transform attackPoint;
    public GameObject enemyBullet;
    private ScoreScript scoreScript;

    
    void Start()
    {
        GameObject scoreObject = GameObject.FindWithTag("Score");
        if (scoreObject != null)
        {
            scoreScript = scoreObject.GetComponent<ScoreScript>();
        }
        if (scoreScript == null)
        {
            Debug.Log("WTF is THAT!!!");
        }

        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    
    void Update()
    {
        Move();
        RotateEnemy();
      
    }

    void Move()
    {
        if (canMove)
        {
            Vector2 temp = transform.position;
            temp.y -= speed * Time.deltaTime;            
            transform.position = temp;           

            if (temp.y < boundY)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(enemyBullet, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().isEnemyBullet = true;

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(1f, 3f));
        }
    }

    void TurnOffGameObject()
    {
        //gameObject.SetActive(false);
       
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            scoreScript.AddScore(scoreValue);

            canMove = false;

            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("StartShooting");
            }

            Invoke("TurnOffGameObject", 0f);
        }
    }

    



}// class
