using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float DeadZone = -7f;
    private Collider2D Collider;


    private void Awake()
    {
        Collider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if(transform.position.y < DeadZone)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(gameObject) ;
        }
        if (collision.tag == "Player")
        {
            GameManager.instance.GameOver();
        }
    }
}
