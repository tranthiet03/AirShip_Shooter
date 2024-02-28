using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed = 5f;
    private float timer = 0;
    private float BulletRate = 95f;
    [SerializeField] private GameObject GunPrefab_Left;
    [SerializeField] private Transform BulletSpawn_Left;

    [SerializeField] private GameObject GunPrefab_Right;
    [SerializeField] private Transform BulletSpawn_Right;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsStartGame()) return;
        float h_Input = Input.GetAxis("Horizontal");
        float v_Input = Input.GetAxis("Vertical");
        body.velocity = new Vector3(h_Input * speed, v_Input * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            if (timer < BulletRate)
            {
                timer++;
            }
            else
            {
                Shoot();
                timer = 0;
            }

        }
    }
    private void Shoot()
    {
        Instantiate(GunPrefab_Left, BulletSpawn_Left.position, BulletSpawn_Left.rotation);
        Instantiate(GunPrefab_Right, BulletSpawn_Right.position, BulletSpawn_Right.rotation);
    }
}
   
