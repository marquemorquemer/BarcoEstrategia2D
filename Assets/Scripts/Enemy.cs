using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] List<Transform> puntos;
    public float speed = 2f;
    public float changeDistance = 0.2f;
    byte nextPosition = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, puntos[nextPosition].transform.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, puntos[nextPosition].transform.position) < changeDistance)
        {
            nextPosition++;
            if (nextPosition >= puntos.Count)
                nextPosition = 0;
        }
    }
}
