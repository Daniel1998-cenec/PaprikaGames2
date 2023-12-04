using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlScript : MonoBehaviour
{
    public List<Button> botones;
    //private string[] nombreBotones = {"arribaIzquierda","arriba","arribaDerecha","izquierda","centro","derecha","abajoIzquierda","abajo","abajoDerecha"};
    public List<Sprite> imagenes;
    [SerializeField] private TextMeshProUGUI textoGanar;
    [SerializeField] private TextMeshProUGUI textoPerder;
    [SerializeField] private TextMeshProUGUI textoEmpate;
    [SerializeField] private Button botonSalir;
    [SerializeField] private Button botonOtraVez;
    public bool turnoJugador;
    public bool fin;
    void Start()
    {
        
    }


    void Update()
    {
        if(!fin)
        {
            if(!turnoJugador)
            {
                TurnoMaquina();
                ComprobarCasillas(imagenes[2]);
            }            
        }
    }

    /*
        0 1 2
        3 4 5
        6 7 8
    */
    public void ComprobarCasillas(Sprite j)
    {
        if(botones[0].GetComponent<Image>().sprite==j && botones[1].GetComponent<Image>().sprite==j && botones[2].GetComponent<Image>().sprite==j ||
        botones[3].GetComponent<Image>().sprite==j && botones[4].GetComponent<Image>().sprite==j && botones[5].GetComponent<Image>().sprite==j ||
        botones[6].GetComponent<Image>().sprite==j && botones[7].GetComponent<Image>().sprite==j && botones[8].GetComponent<Image>().sprite==j ||
        botones[0].GetComponent<Image>().sprite==j && botones[3].GetComponent<Image>().sprite==j && botones[6].GetComponent<Image>().sprite==j ||
        botones[1].GetComponent<Image>().sprite==j && botones[4].GetComponent<Image>().sprite==j && botones[7].GetComponent<Image>().sprite==j ||
        botones[2].GetComponent<Image>().sprite==j && botones[5].GetComponent<Image>().sprite==j && botones[8].GetComponent<Image>().sprite==j ||
        botones[0].GetComponent<Image>().sprite==j && botones[4].GetComponent<Image>().sprite==j && botones[8].GetComponent<Image>().sprite==j ||
        botones[2].GetComponent<Image>().sprite==j && botones[4].GetComponent<Image>().sprite==j && botones[6].GetComponent<Image>().sprite==j)
        {
            if(j == imagenes[1]){
                Debug.Log("Has Ganado.");
                textoGanar.gameObject.SetActive(true);
                botonSalir.gameObject.SetActive(true);
            }else{
                Debug.Log("Has Perdido.");
                textoPerder.gameObject.SetActive(true);
                botonOtraVez.gameObject.SetActive(true);
            }
            
            fin = true;
            
        }

        if(!fin && (botones[0].GetComponent<Image>().sprite != imagenes[0] && botones[1].GetComponent<Image>().sprite != imagenes[0] &&
        botones[2].GetComponent<Image>().sprite != imagenes[0] && botones[3].GetComponent<Image>().sprite != imagenes[0] &&
        botones[4].GetComponent<Image>().sprite != imagenes[0] && botones[5].GetComponent<Image>().sprite != imagenes[0] &&
        botones[6].GetComponent<Image>().sprite != imagenes[0] && botones[7].GetComponent<Image>().sprite != imagenes[0] &&
        botones[8].GetComponent<Image>().sprite != imagenes[0]))
        {
            textoEmpate.gameObject.SetActive(true);
            botonOtraVez.gameObject.SetActive(true);
            fin = true;
        }
    }

    private void TurnoMaquina()
    {
        if(botones[4].GetComponent<Image>().sprite == imagenes[0])
        {
            Debug.Log("El enemigo ha cogido el centro");
            botones[4].GetComponent<Image>().sprite = imagenes[2];
            turnoJugador = true;
            
        }else
        {
            Debug.Log("El enemigo se dispone a marcar una casilla");
            
            int r;
            do{
                r = Random.Range(0, 9);
            }while(botones[r].GetComponent<Image>().sprite!=imagenes[0]);

            botones[r].GetComponent<Image>().sprite = imagenes[2];

            turnoJugador = true;
            
        }

    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SalirJuego()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
