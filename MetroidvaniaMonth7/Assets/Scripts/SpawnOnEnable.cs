using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnEnable : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float spawnRate = 30f;
    float timeBeforeSpawn = 0f;


    void Start()
    {
        if (enemy != null)
        {
            health = enemy.GetComponent<IHealth>();
        }
    }


    IHealth health;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (CanSpawn())
        {
            SetupEnemy();
        }
    }


    void SetupEnemy()
    {
        if(enemy != null && health != null)
        {
            health.CurrentHealth = health.MaxHealth;
            health.IsDead = false;
            enemy.GetComponent<Collider2D>().enabled = true;
            enemy.GetComponentInChildren<SpriteRenderer>().enabled = true;
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
        }
    }
    // Update is called once per frame
    bool CanSpawn()
    {
        if (Time.time >= timeBeforeSpawn)
        {
            timeBeforeSpawn = Time.time + spawnRate;

            return true;
        }
        else
        {
            return false;
        }

    }
}
