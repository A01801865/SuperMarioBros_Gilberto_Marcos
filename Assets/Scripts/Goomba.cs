// Gilberto de Jesús Marcos Orozco A01801865

using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaPatrullaje = 3f; 
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 posicionInicial;
    private int direccion = -1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        
        posicionInicial = transform.position;

       
        if (rb != null) rb.freezeRotation = true;
    }

    void Update()
    {
        
        rb.linearVelocityX = velocidad * direccion;

        //movimiento del Goomba
        if (transform.position.x < posicionInicial.x - distanciaPatrullaje)
        {
            direccion = 1;
            spriteRenderer.flipX = true; 
        }
        else if (transform.position.x > posicionInicial.x + distanciaPatrullaje)
        {
            direccion = -1; 
            spriteRenderer.flipX = false; 
        }
    }

//muerte del jugador si toca al goomba
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Goomba eliminó al jugador");
            Destroy(collision.gameObject);
        }
    }
}