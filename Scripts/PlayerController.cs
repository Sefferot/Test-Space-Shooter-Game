using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float max_X, min_X;
    public int health;
    public Text healthText;

    public GameObject FinishPanel;

    [SerializeField]
    private GameObject playerBullet;

    [SerializeField]
    private Transform attackPoint;

    public float attackTimer = 0.35f;
    private float currentAttackTimer;
    private bool canAttack;
    
    void Start()
    {
        currentAttackTimer = attackTimer;
        Time.timeScale = 0;
    }

    
    void Update()
    {
        MovePlayer();
        Attack();

        healthText.text ="health " + health.ToString();
    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector2 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_X) temp.x = max_X;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector2 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x < min_X) temp.x = min_X;

            transform.position = temp;
        }       
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer > currentAttackTimer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canAttack)
            {
                canAttack = false;
                attackTimer = 0f;

                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);
                // play sound FX
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet" || target.tag == "Enemy")
        {
            health--;
            if (health == 0)
            {
                healthText.text = "0";
                Time.timeScale = 0;
                Destroy(gameObject);
                FinishPanel.SetActive(true);
            }
        }
    }
    



} // class
