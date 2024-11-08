using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// Clase principal que gestiona la lógica del juego
/// Controla el estado del juego, los obstáculos y el movimiento del escenario
public class GameManager : MonoBehaviour
{
    public GameObject Menú;//Menú de inicio
    public GameObject GameOver;//Pantalla de Game Over
    public float velocidad = 2; //Velocidad de movimiento del escenario
    public GameObject Columna; //Prefab de la columna
    public List<GameObject> columnas; //Lista de columnas
    public List<GameObject> Obstaculos; //Lista de obstáculos
    public GameObject Piedra;//Prefab de la piedra
    public GameObject PiedraPequeña;//Prefab de la piedra pequeña
    public bool gameOver = false;//Variable que indica si el juego ha terminado
    public bool StartGame = false;//Variable que indica si el juego ha comenzado
    public Renderer fondo;//Fondo del escenario
    // Start is called before the first frame update
    void Start()
        //crear mapa
    {
        for(int i=0; i<21; i++) //Crear columnas
        {
         columnas.Add(Instantiate(Columna, new Vector2(-10 + i, -3), Quaternion.identity)); //Instanciar columna
        }
        //Crear piedras

        Obstaculos.Add(Instantiate(Piedra, new Vector2(15,-2), Quaternion.identity)); //Instanciar piedra
        Obstaculos.Add(Instantiate(PiedraPequeña, new Vector2(20, -2), Quaternion.identity)); //Instanciar piedra pequeña
    }

    // Update is called once per frame
    void Update()
    {
        if(StartGame == false) //Si el juego no ha comenzado
        {
            if (Input.GetKeyDown(KeyCode.Space)) //Si se presiona la tecla espacio
            {
                StartGame = true; //Comenzar el juego
            }
        }

        if (StartGame == true && gameOver == true) //Si el juego ha comenzado y ha terminado
        {
            GameOver.SetActive(true); //Mostrar pantalla de Game Over
            if (Input.GetKeyDown(KeyCode.Space))  //Si se presiona la tecla espacio
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Recargar la escena
            }
        }

        if (StartGame == true && gameOver == false) //Si el juego ha comenzado y no ha terminado
        {
            Menú.SetActive(false); 
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.025f, 0) * Time.deltaTime; //Mover fondo

            //mover mapa
            for (int i = 0; i < columnas.Count; i++) //Mover columnas
            {
                if (columnas[i].transform.position.x <= -10) //Si la columna sale de la pantalla
                {
                    columnas[i].transform.position = new Vector3(10, -3, 0); //Reubicar la columna
                }
                columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad; //Mover la columna
            }
            //spawnear piedras u obstaculos
            for (int i = 0; i < Obstaculos.Count; i++) //Mover obstáculos
            {
                if (Obstaculos[i].transform.position.x <= -10) //Si el obstáculo sale de la pantalla
                {
                    float randomObs = Random.Range(11, 18); //Generar una posición aleatoria
                    Obstaculos[i].transform.position = new Vector3(randomObs, -2, 0); //Reubicar el obstáculo
                }
                Obstaculos[i].transform.position = Obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad; //Mover el obstáculo
            }
        }
    }
}
