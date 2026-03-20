using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private UIDocument _documento;
    private VisualElement _root;

    private VisualElement _ventanaAyuda;
    private VisualElement _ventanaCreditos;
    private VisualElement _contenedorBotones;
    private VisualElement _listaTexto;
    private VisualElement _contenedorScroll;

    public float velocidadSubida = 50f;
    private float _posicionY = 0f;

    void OnEnable()
    {
        _documento = GetComponent<UIDocument>();
        _root = _documento.rootVisualElement;

        //ventanas
        _ventanaAyuda = _root.Q<VisualElement>("VentanaAyuda");
        _ventanaCreditos = _root.Q<VisualElement>("VentanaCreditos");
        _contenedorBotones = _root.Q<VisualElement>("Botones");
        _contenedorScroll = _root.Q<VisualElement>("Scroll");
        _listaTexto = _root.Q<VisualElement>("ListaTexto");

        //botones
        _root.Q<Button>("Jugar").clicked += () => SceneManager.LoadScene("SampleScene");
        _root.Q<Button>("Ayuda").clicked += () => AbrirSeccion(_ventanaAyuda);
        _root.Q<Button>("Creditos").clicked += () => AbrirSeccion(_ventanaCreditos);

        //boton cerrar el juego
        Button btnSalir = _root.Q<Button>("BotonCerrarJuego");
        if (btnSalir != null)
        {
            btnSalir.clicked += SalirDelJuego;
        }

        //boton cerrar ventanas
        _root.Query<Button>("BotonCerrar").ForEach(btn => {
            btn.clicked += RegresarAlMenu;
        });
    }

    void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); // Cierra el juego 

        #if UNITY_EDITOR
        // Probar que se cierra el juego apagando el play con Unity
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Update()
    {
        // Movimiento de créditos
        if (_ventanaCreditos != null && _ventanaCreditos.style.display == DisplayStyle.Flex && _listaTexto != null)
        {
            _posicionY -= velocidadSubida * Time.deltaTime;
            _listaTexto.style.translate = new Translate(0, _posicionY, 0);

            float alturaTexto = _listaTexto.layout.height;
            float alturaMascara = _contenedorScroll.layout.height;

            if (Mathf.Abs(_posicionY) > alturaTexto)
            {
                _posicionY = alturaMascara; 
            }
        }
    }
//abrir ventana
    void AbrirSeccion(VisualElement ventana)
    {
        if (ventana != null && _contenedorBotones != null)
        {
            _contenedorBotones.style.display = DisplayStyle.None;
            ventana.style.display = DisplayStyle.Flex;
            if (ventana == _ventanaCreditos) _posicionY = 0f;
        }
    }

    void RegresarAlMenu()
    {
        if (_ventanaAyuda != null) _ventanaAyuda.style.display = DisplayStyle.None;
        if (_ventanaCreditos != null) _ventanaCreditos.style.display = DisplayStyle.None;
        if (_contenedorBotones != null) _contenedorBotones.style.display = DisplayStyle.Flex;
    }
}