using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
/**
Controladores para los botones en el UI
Autor: Sebastián Álvarez Fuentes
*/

public class UIManager : MonoBehaviour
{
    private VisualElement root;
    private VisualElement menuContainer;
    private VisualElement ayudaContainer;

    void OnEnable()
    {
        // Obtener la raíz del UI Toolkit
        root = GetComponent<UIDocument>().rootVisualElement;

        // Buscar los contenedores en el UI
        menuContainer = root.Q<VisualElement>("menuContainer");
        ayudaContainer = root.Q<VisualElement>("ayudaContainer");

        // Buscar botones y asignar eventos
        Button btnAyuda = root.Q<Button>("btnAyuda");
        Button btnCerrarInfo = root.Q<VisualElement>("Cerrar")?.Q<Button>("CerrarInfo");
        Button btnJugar = root.Q<Button>("btnJugar");
        Button btnCreditos = root.Q<Button>("btnCreditos");
        Button btnTache = root.Q<Button>("tache"); // Buscar el botón tache

        if (btnAyuda != null) btnAyuda.clicked += MostrarAyuda;
        if (btnCerrarInfo != null) btnCerrarInfo.clicked += CerrarAyuda;
        if (btnJugar != null) btnJugar.clicked += CambiarEscena;
        if (btnCreditos != null) btnCreditos.clicked += CambiarCreditos;
        if (btnTache != null) btnTache.clicked += CerrarJuego; // Asignar evento para cerrar el juego
    }

    private void MostrarAyuda()
    {
        // Ocultar menú y mostrar ayuda
        menuContainer.style.display = DisplayStyle.None;
        ayudaContainer.style.display = DisplayStyle.Flex;
    }

    private void CerrarAyuda()
    {
        // Ocultar ayuda y mostrar el menú
        ayudaContainer.style.display = DisplayStyle.None;
        menuContainer.style.display = DisplayStyle.Flex;
    }

    private void CambiarEscena()
    {
        // Cargar la escena de juego
        SceneManager.LoadScene("SampleScene");
    }

    private void CambiarCreditos()
    {
        // Cargar la escena de créditos
        SceneManager.LoadScene("Creditos");
    }

    private void CerrarJuego()
    {
        // Cerrar la aplicación
        Application.Quit();
        
        // Para el modo editor en Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}