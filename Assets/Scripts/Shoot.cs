using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float timeToShoot = 3;
    public bool isPlayer;

    private void Start()
    {
        if(!isPlayer)
        {
            StartCoroutine(ShootingEnemy());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                ShootBullet(GetComponent<Movement>().directionShoot);
            }
        }        
    }
    void ShootBullet(Vector2 dir)
    {
        GameObject bulletGO = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletGO.GetComponent<Bullet>().DirectionBullet(dir);
        if(isPlayer)
        {
            bulletGO.GetComponent<SpriteRenderer>().color = Color.green;
            bulletGO.GetComponent<Bullet>().target = "Enemy";
        }
        else
        {
            bulletGO.GetComponent<SpriteRenderer>().color = Color.red;
            bulletGO.GetComponent<Bullet>().target = "Player";
        }
    }
    IEnumerator ShootingEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeToShoot);
            ShootBullet(GetComponent<FollowTarget>().directionFollow);
        }
    }
}
