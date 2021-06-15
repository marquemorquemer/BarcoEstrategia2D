using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public Vector2 direction;
    public float speed = 10;
    public string target;
    public float timeToDestroy = 3;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(target))
        {
            Health health = other.GetComponent<Health>();
            if (health == null)
                return;
            health.TakeDamage(damage);
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
    }
    public void DirectionBullet(Vector2 dir)
    {
        direction = dir;
    }
}
