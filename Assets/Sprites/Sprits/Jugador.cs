using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour 
{
    public float fuerzaSalto; //Fuerza de salto del jugador
    public GameManager gameManager; // se llama a GameManager
    private Rigidbody2D rigidbody2D; //Rigidbody del jugador
    private Animator animator;//Animator del jugador
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); //Obtener el animator del jugador
        rigidbody2D = GetComponent<Rigidbody2D>(); //Obtener el Rigidbody del jugador
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //Si se presiona la tecla espacio
        {
            animator.SetBool("EstaSaltando", true); //Activar la animación de salto
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto)); //Aplicar fuerza de salto
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //Cuando el jugador colisiona con otro objeto
    {
        if (collision.gameObject.tag == "Suelo") //Si colisiona con el suelo
        {
            animator.SetBool("EstaSaltando", false); //Desactivar la animación de salto
        }
        if (collision.gameObject.tag == "Obstaculo") //Si colisiona con un obstáculo
        {
            gameManager.gameOver = true; //El juego ha terminado
        }
    }
}
