using UnityEngine;
/**
Modifica los parámetros del animator del personaje
Autor: Sebastián Álvarez Fuentes
*/
public class CambiaAnimacion : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spRenderer;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  
        spRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Modificar el parámetro del animator
        animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocityX));
        spRenderer.flipX = rb.linearVelocityX < 0;
        animator.SetBool("enPiso", EstadoPersonaje.enPiso);
    }
}