using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover; //En las 4 direcciones
    [SerializeField]
    private InputAction accionSaltar; //para saltar con espacio
    private float velocidadX = 7f;
    private float velocidadY = 7f;

    private Rigidbody2D rb; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Habilitar el InputAction
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>();
    }
     // otra forma para habilitar el InputAction
    void OnEnable()
    {
        accionSaltar.Enable();
        accionSaltar.performed += saltar;
    }

    //no está habilitado
    void OnDisable()
    {
        accionSaltar.Disable();
        accionSaltar.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context)
    {
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocityY = velocidadY * 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Leer la entrada
        Vector2 movimiento = accionMover.ReadValue<Vector2>();
        //transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento;
        rb.linearVelocityX = velocidadX * movimiento.x;
    }
}