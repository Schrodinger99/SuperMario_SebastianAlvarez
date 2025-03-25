using UnityEngine;
/**
Controlador para el funcionamiento de las monedas
Autor: Sebastián Álvarez Fuentes
*/

public class ItemMoneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // El personaje colisionó con la moneda

            // Prende la explosión
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // Apaga la moneda
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            // Destruye el objeto y la moneda
            Destroy(gameObject, 0.3f);
        }
    }
}
