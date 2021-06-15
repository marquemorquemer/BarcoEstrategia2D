using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleccionDeBarco : MonoBehaviour
{
    public Movement movBarco;
    public Rigidbody2D rb2D;

    public float speedBlindado = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Barco Seleccionado, {0}" + this.name);

        movBarco.rb = rb2D;
    }

}
