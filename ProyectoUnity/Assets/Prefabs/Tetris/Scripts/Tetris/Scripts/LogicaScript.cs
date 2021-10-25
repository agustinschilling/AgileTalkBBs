using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogicaScript : MonoBehaviour
{
    // para centrarlo en el tele
    public static int dezplazamientoZ = 12;
    public static int dezplazamientoY = 4;
    public static float scale = 0.05f;

    private float tiempoAnterior;
    public float tiempoCaida = 0.8f;

    public static int alto = 20;
    public static int ancho = 10;

    public Vector3 puntoRotacion;

    private static Transform[,] grid = new Transform [ancho, alto];

    private static bool Termino = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Tiempo>().PlayGame();
        

    }

    // Update is called once per frame
    void Update()
    {
        // Izquierda // eje z
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position += new Vector3(0, 0, -scale );
            if (!Limites()) {
                transform.position -= new Vector3(0, 0, -scale);
            }
        }

        // Derecha // eje z
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += new Vector3(0, 0, scale);
            if (!Limites()) {
                transform.position -= new Vector3(0, 0, scale);
            }
        }


        // tiempo de caida.. // apreta abajo el tiempo se acelera
        if (Time.time - tiempoAnterior > (Input.GetKey(KeyCode.DownArrow)? tiempoCaida/20 : tiempoCaida)) {
            transform.position += new Vector3(0, -scale, 0);
            if (!Limites()) {
                transform.position -= new Vector3(0, -scale, 0);

                agregarAlGrid();

                RevisarLineas();

                this.enabled = false;
                
                // cuando desactiva, genera otro objeto
                if (!Termino) {
                    FindObjectOfType<LogicaGenerador>().NuevaFigura(scale);
                }
            }
            tiempoAnterior = Time.time;
        }


        // Flecha arriba  // rota 90 grados
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.RotateAround(transform.TransformPoint(puntoRotacion), new Vector3(1,0,0), -90);
            if (!Limites()) {
                transform.RotateAround(transform.TransformPoint(puntoRotacion), new Vector3(1,0,0), 90);
            }
        }


    }


    bool Limites() {
        foreach(Transform hijo in transform) {
            int enteroZ = Mathf.RoundToInt((hijo.transform.position.z - dezplazamientoZ) / scale);
            int enteroY = Mathf.RoundToInt((hijo.transform.position.y - dezplazamientoY) / scale);

            if(enteroZ < 0 || enteroZ >= ancho || enteroY < 0 || enteroY >= alto) {
                return false;
            }

            // si choca con otro objeto
            if(grid[enteroZ, enteroY] != null) {
                return false;
            }
        }
        return true;
    }


    void agregarAlGrid() {
        foreach(Transform hijo in transform) {
            int enteroZ = Mathf.RoundToInt((hijo.transform.position.z - dezplazamientoZ) / scale);
            int enteroY = Mathf.RoundToInt((hijo.transform.position.y - dezplazamientoY) / scale);

            grid[enteroZ, enteroY] = hijo;

            if(enteroY >= 19) {
                Debug.Log("Gammer Over... Hizo: " + FindObjectOfType<Puntos>().getPuntos() + " puntos, en: " + (99 - FindObjectOfType<Tiempo>().getTiempo()) + " segundos.");
                Termino = true;
                FindObjectOfType<Tiempo>().Stop();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                // ACA FALTA ELIMINAR TODO, MOSTRAR RESULTADO ETC...
            }

        }
    }

    void RevisarLineas() {
        for(int i = alto -1; i >= 0; i--) {
            if(TieneLinea(i)) {
                BorrarLinea(i);
                BajarLinea(i);
            }
        }
    }

    bool TieneLinea(int i) {
        for (int j = 0; j < ancho; j++) {
            if (grid[j,i] == null) {
                return false;
            }
        }
        return true;
    }

    void BorrarLinea(int i) {
        for (int j = 0; j < ancho; j++) {
            Destroy(grid[j,i].gameObject);
            grid[j,i] = null;
        }
        FindObjectOfType<Puntos>().Sumar();
    }

    void BajarLinea(int i) {
        for (int y = i; y < alto; y++) {
            for (int j = 0; j < ancho; j++) {
                if(grid[j,y] != null) {
                    grid[j,y-1] = grid[j,y];
                    grid[j,y] = null;
                    grid[j, y-1].transform.position -= new Vector3(0,scale,0);
                }
            }
        }
    }

}

