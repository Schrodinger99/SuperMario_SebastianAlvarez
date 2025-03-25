using UnityEngine;

/** 
Para saber si el personaje está en el piso o no
Autor: Sebastián Álvarez Fuentes
*/
public class EstadoPersonaje : MonoBehaviour
{
    public static bool enPiso { get; private set; }

     void OnTriggerEnter2D(Collider2D collision)
     {
        enPiso = true;
     }

     void OnTriggerExit2D(Collider2D collision)
     {
        enPiso = false;
     }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enPiso = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}