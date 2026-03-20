using UnityEngine;

public class Goomba : MonoBehaviour
{
    private Rigidbody2D rb;

    public float velocidad = 2f;
    private int direccion = -1; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
//movimiento goomba
    void Update()
    {

        rb.linearVelocity = new Vector2(velocidad * direccion, rb.linearVelocity.y);
    }
//destruir al jugador al colisionar 
    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            return;
        }

        //dirección del goomba
        foreach (ContactPoint2D contacto in collision.contacts)
        {
            if (Mathf.Abs(contacto.normal.x) > 0.5f)
            {
                direccion *= -1;
                break;
            }
        }
    }
}