using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
/**
Genera el loop para el autoscroll de los creditos
Autor: Sebastián Álvarez Fuentes
*/

public class AutoScrollCredits : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 100f;
    [SerializeField] private bool enableLoop = true;
    [SerializeField] private float startDelay = 0.3f; 
    [SerializeField] private float initialOffset = 200f; 
    [SerializeField] private float maxScrollReduction = 150f;

    private UIDocument document;
    private ScrollView scrollView;
    private VisualElement contentContainer;
    private VisualElement creditosElem;
    private VisualElement duplicadoElem;
    private float creditosHeight = 0f;
    private float viewportHeight = 0f;
    private float currentPosition = 0f;
    private bool setupComplete = false;
    private bool duplicateCreated = false;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        if (document == null) return;

        var root = document.rootVisualElement;
        scrollView = root.Q<ScrollView>("scrollText");

        if (scrollView != null)
        {
            contentContainer = scrollView.Q("unity-content-container");
            scrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;

            StartCoroutine(DelayedSetup());
        }
    }

    private IEnumerator DelayedSetup()
    {
        yield return new WaitForSeconds(startDelay);

        creditosElem = contentContainer.Q("creditos");

        if (creditosElem != null)
        {
            creditosHeight = creditosElem.layout.height;
            viewportHeight = scrollView.layout.height;

            // 🔹 Ajusta la posición inicial para empezar más abajo
            currentPosition = -initialOffset;
            scrollView.scrollOffset = new Vector2(0, currentPosition);

            if (enableLoop && !duplicateCreated)
            {
                CreateDuplicate();
            }

            setupComplete = true;
        }
    }

    private void CreateDuplicate()
    {
        if (duplicateCreated) return;

        if (creditosElem is Label creditosLabel)
        {
            var duplicadoLabel = new Label
            {
                name = "creditosDuplicado",
                text = creditosLabel.text
            };
            duplicadoLabel.AddToClassList("creditosStyle");
            duplicadoLabel.style.position = Position.Relative;

            // 🔹 Ocultamos el duplicado hasta que sea necesario
            duplicadoLabel.style.display = DisplayStyle.None;

            contentContainer.Add(duplicadoLabel);
            duplicadoElem = duplicadoLabel;
        }
        else
        {
            Debug.LogWarning("El elemento 'creditos' no es un Label.");
        }

        duplicateCreated = true;
    }

    private void Update()
    {
        if (!setupComplete || scrollView == null) return;

        currentPosition += scrollSpeed * Time.deltaTime;

        // 🔹 Se actualiza el resetPoint para evitar que el duplicado aparezca antes de tiempo
        float resetPoint = enableLoop && duplicadoElem != null
            ? creditosHeight + viewportHeight - maxScrollReduction  // 🔹 Espera a que el original termine
            : creditosHeight + viewportHeight - maxScrollReduction;

        if (currentPosition >= resetPoint)
        {
            // 🔹 Ahora mostramos el duplicado justo cuando el original desaparece
            if (enableLoop && duplicadoElem != null)
            {
                duplicadoElem.style.display = DisplayStyle.Flex;
            }

            currentPosition = enableLoop ? -initialOffset : -viewportHeight;
        }

        scrollView.scrollOffset = new Vector2(0, currentPosition);
    }
}