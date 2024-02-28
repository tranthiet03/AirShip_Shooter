using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed_bullet = 5f;
    private float deadZone = -6f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
