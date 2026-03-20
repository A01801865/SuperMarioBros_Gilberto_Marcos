using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuRegresa : MonoBehaviour
{
    private UIDocument _documento;
    private VisualElement _root;

    void OnEnable()
    {
        _documento = GetComponent<UIDocument>();
        _root = _documento.rootVisualElement;

        // Buscamos el botón que se llama "Regresa"
        Button btnRegresa = _root.Q<Button>("BotonRegresa");

        if (btnRegresa != null)
        {
            // Al hacer clic, carga la escena del Menú
            // Asegúrate de que tu escena de inicio se llame "Menu"
            btnRegresa.clicked += () => SceneManager.LoadScene("Menu");
        }
    }
}