using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
/**
Controlador para el botón de la escena Creditos
Autor: Sebastián Álvarez Fuentes
*/

public class SceneController : MonoBehaviour
{
    private void OnEnable()
    {
        // Obtiene el UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Busca el botón dentro del contenedor
        Button btnCerrar = root.Q<VisualElement>("Boton")?.Q<Button>("Cerrar");

        // Verifica si el botón existe y le asigna el evento
        if (btnCerrar != null)
        {
            btnCerrar.clicked += () => SceneManager.LoadScene("MenuPrincipal");
        }
        else
        {
            Debug.LogError("No se encontró el botón 'Cerrar' en la UI");
        }
    }
}
