using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public bool following = true;
    public float speed = 2;
    public Vector2 directionFollow;
    private Rigidbody2D rb;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Blindado").transform;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }
    private void FixedUpdate()
    {
        if(following && target != null)
        {
            DirectionToGo();
            //transform.Translate(directionFollow * speed * Time.deltaTime);
            rb.velocity = new Vector2(directionFollow.x, directionFollow.y) * speed * Time.fixedDeltaTime;
        }
    }
    public void DirectionToGo()
    {
        directionFollow = (target.position - transform.position).normalized;
    }
}
