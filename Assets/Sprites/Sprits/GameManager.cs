using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Menú;
    public GameObject GameOver;
    public float velocidad = 2;
    public GameObject Columna;
    public List<GameObject> columnas;
    public List<GameObject> Obstaculos;
    public GameObject Piedra;
    public GameObject PiedraPequeña;
    public bool gameOver = false;
    public bool StartGame = false;
    public Renderer fondo;
    // Start is called before the first frame update
    void Start()
        //crear mapa
    {
        for(int i=0; i<21; i++ )
        {
         columnas.Add(Instantiate(Columna, new Vector2(-10 + i, -3), Quaternion.identity));
        }
        //Crear piedras

        Obstaculos.Add(Instantiate(Piedra, new Vector2(15,-2), Quaternion.identity));
        Obstaculos.Add(Instantiate(PiedraPequeña, new Vector2(20, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if(StartGame == false )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame = true;
            }
        }

        if (StartGame == true && gameOver == true)
        {
            GameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (StartGame == true && gameOver == false)
        {
            Menú.SetActive(false);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.025f, 0) * Time.deltaTime;

            //mover mapa
            for (int i = 0; i < columnas.Count; i++)
            {
                if (columnas[i].transform.position.x <= -10)
                {
                    columnas[i].transform.position = new Vector3(10, -3, 0);
                }
                columnas[i].transform.position = columnas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            //spawnear piedras u obstaculos
            for (int i = 0; i < Obstaculos.Count; i++)
            {
                if (Obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 18);
                    Obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                Obstaculos[i].transform.position = Obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
