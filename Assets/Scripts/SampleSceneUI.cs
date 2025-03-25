using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
/**
Controlador del botón del juego
Autor: Sebastián Álvarez Fuentes
*/
public class SampleSceneUI : MonoBehaviour
{
    private void OnEnable()
    {
        // Obtiene el UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Busca el botón dentro del contenedor
        Button btnRegresar = root.Q<VisualElement>("contenedor")?.Q<Button>("regresar");

        // Verifica si el botón existe y le asigna el evento
        if (btnRegresar != null)
        {
            btnRegresar.clicked += () => SceneManager.LoadScene("MenuPrincipal");
        }
        else
        {
            Debug.LogError("No se encontró el botón 'regresar' en la UI");
        }
    }
}