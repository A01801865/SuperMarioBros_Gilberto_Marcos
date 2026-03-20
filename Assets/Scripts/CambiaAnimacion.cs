//Gilberto de Jesús Marcos Orozco A01801865

using System;
using UnityEngine;

public class CambiaAnimacion : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private EstadoPersonaje estado;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidad", MathF.Abs(rb.linearVelocityX));

        //Manejar el FLIP_X
        sr.flipX= rb.linearVelocityX < 0;

        //Manejar animación de salto
        animator.SetBool("enPiso", estado.estaEnPiso);
    }
}
