using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    public List<string> Frases = new List<string>
    {
        "Una _ _ _ _ _ _ _ _ _ _ no hace verano",
        "El que a _ _ _ _ _ _ mata, a _ _ _ _ _ _ muere",
        "Un _ _ _ _ _ saca otro _ _ _ _ _",
        "A _ _ _ _ _ _ _ que huye, puente de plata",
        "La _ _ _ _ _ _ _ _ rompe el saco",
        "Más vale _ _ _ _ _ _ _ _ que curar",
        "Primero es la _ _ _ _ _ _ _ _ _ que la devoción",
        "A palabras _ _ _ _ _ _ , oídos sordos"

    };
    public List<string> botones = new List<string>
    {
        "golondrina","jirafa","mariposa","hierro","lingote","barra","clavo","tornillo","clavija","enemigo","antagonista","villano, avaricia, ambicion, suerte, prevenir, reemplazar, anticiparse, obligacion, exigencia, esperanza, necias, acefalas, simples"
    };
    public TextMeshProUGUI fraseAleatoria;
    public Button boton1;
    public Button boton2;
    public Button boton3;
    public Button botonReinicio;
    public Button botonSalirNivel;
    public TextMeshProUGUI texto1;
    public TextMeshProUGUI texto2;
    public TextMeshProUGUI texto3;

    // Start is called before the first frame update
    void Start()
    {
        // --------------------------------------------frases-----------------------------------------------------------
        if (Frases.Count == 0)
        {
            Debug.LogError("La lista de frases está vacía. Asegúrate de añadir frases en el Inspector.");
            return;
        }

        // Mezclar las frases usando el algoritmo de Fisher-Yates
        FrasesAleatorias();

        // Obtener la primera frase de la lista (que ahora está mezclada)
        string primeraFrase = Frases[0];

        // Mostrar la primera frase en el TextMeshProUGUI
        if (fraseAleatoria != null)
        {
            fraseAleatoria.text = primeraFrase;
        }
        else
        {
            Debug.LogError("El componente TextMeshProUGUI no está asignado en el Inspector.");
        }

        // -------------------------------------------------botones----------------------------------------------------------

        if (botones.Count < 3)
        {
            Debug.LogError("La lista de botones debe contener al menos tres elementos.");
            return;
        }

        // Mezclar los botones usando el algoritmo de Fisher-Yates
        ShuffleBotones();

        texto1.text = botones[0];
        texto2.text = botones[1];
        texto3.text = botones[2];

        
        if (fraseAleatoria.text == "Una _ _ _ _ _ _ _ _ _ _ no hace verano")
        {
            texto1.text = "golondrina";
            texto2.text = "jirafa";
            texto3.text = "mariposa";
        }
        else if (fraseAleatoria.text == "El que a _ _ _ _ _ _ mata, a _ _ _ _ _ _ muere")
        {
            texto1.text = "lingote";
            texto2.text = "hierro";
            texto3.text = "barra";
        }
        else if (fraseAleatoria.text == "Un _ _ _ _ _ saca otro _ _ _ _ _")
        {
            texto1.text = "tornillo";
            texto2.text = "clavija";
            texto3.text = "clavo";
        } else if(fraseAleatoria.text == "A _ _ _ _ _ _ _ que huye, puente de plata")
        {
            texto1.text = "enemigo";
            texto2.text = "antagonista";
            texto3.text = "villano";
        }
        else if (fraseAleatoria.text == "La _ _ _ _ _ _ _ _ rompe el saco")
        {
            texto1.text = "suerte";
            texto2.text = "avaricia";
            texto3.text = "ambicion";
        }
        else if (fraseAleatoria.text == "Más vale _ _ _ _ _ _ _ _ que curar")
        {
            texto1.text = "anticiparse";
            texto2.text = "prevenir";
            texto3.text = "reemplazar";
        }
        else if (fraseAleatoria.text == "Primero es la _ _ _ _ _ _ _ _ _ que la devoción")
        {
            texto1.text = "esperanza";
            texto2.text = "exigencia";
            texto3.text = "obligacion";
        }
        else if (fraseAleatoria.text == "A palabras _ _ _ _ _ _ , oídos sordos")
        {
            texto1.text = "simples";
            texto2.text = "necias";
            texto3.text = "acefalas";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FrasesAleatorias()
    {
        int numeroFrases = Frases.Count;
        System.Random generadorDeRandom = new System.Random();

        while (numeroFrases > 1)
        {
            numeroFrases--;
            int frasesRamdon = generadorDeRandom.Next(numeroFrases + 1);
            string resultadoFraseAleatoria = Frases[frasesRamdon];
            Frases[frasesRamdon] = Frases[numeroFrases];
            Frases[numeroFrases] = resultadoFraseAleatoria;
        }
    }

    private void ShuffleBotones()
    {
        int totalBotones = botones.Count;
        System.Random randomGenerator = new System.Random();

        while (totalBotones > 1)
        {
            totalBotones--;
            int randomIndex = randomGenerator.Next(totalBotones + 1);
            string currentBoton = botones[randomIndex];
            botones[randomIndex] = botones[totalBotones];
            botones[totalBotones] = currentBoton;
        }
    }

    public void VerificarRespuesta(TextMeshProUGUI respuesta)
    {
        Debug.Log(respuesta.text);
        if (respuesta.text == "golondrina")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: Una golondrina no hace verano";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }else if (respuesta.text == "hierro")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: El que a hierro mata, a hierro muere";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }else if (respuesta.text == "clavo")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: Un clavo saca otro clavo";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }else if (respuesta.text == "enemigo")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: A enemigo que huye, puente de plata";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }
        else if (respuesta.text == "avaricia")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: La avaricia rompe el saco";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }
        else if (respuesta.text == "prevenir")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: Más vale prevenir que curar";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }
        else if (respuesta.text == "obligacion")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: Primero es la obligacion que la devoción";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }
        else if (respuesta.text == "necias")
        {
            fraseAleatoria.text = "¡Correcto! La frase es: A palabras necias , oídos sordos";
            botonSalirNivel.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("Le has dado al boton");
        }
        else
        {
            fraseAleatoria.text = "Te has equivocado. Fin del juego.";
            botonReinicio.gameObject.SetActive(true);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            Debug.Log("le has dado al boton incorrecto");
            // Aquí podrías agregar lógica adicional, como reiniciar el juego.
        }

    }

    public void BotonReinicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

}
