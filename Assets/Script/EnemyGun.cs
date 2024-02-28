using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float speed = 5f;
    private float timer = 0;
    [SerializeField] private float BulletTime = 95f;
    [SerializeField] private GameObject Ene_Prefab;
    [SerializeField] private Transform BulletSpawn;


    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (timer < BulletTime)
            {
                timer++;
            }
            else
            {
                Shoot();
                timer = 0;
            }
    }
    private void Shoot()
    {
        Instantiate(Ene_Prefab, BulletSpawn.position, BulletSpawn.rotation);

    }
}
