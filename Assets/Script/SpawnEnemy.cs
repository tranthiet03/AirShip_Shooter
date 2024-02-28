using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    public float SpawnRate = 2f;

    private void Update()
    {
        if (!GameManager.instance.isStart) return;
    }
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    
    
    IEnumerator Spawner()
    {
        while(true)
        {
            int randomValue = Random.Range(0, enemy.Length);
            int range = Random.Range(-10, 10);
            GameObject gameObject = Instantiate(enemy[randomValue], new Vector2(range, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(SpawnRate);
            Destroy(gameObject);
        }
    }
    
}
