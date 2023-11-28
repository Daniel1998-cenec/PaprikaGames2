using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlAcertijos : MonoBehaviour
{
    public TMP_Text acertijoText;
    public TMP_InputField respuestaInput;
    public Button botonReinicio;

    private List<string> acertijos = new List<string>
    {
        "Por un caminito, va caminando un bicho. El nombre del bicho ya te lo he dicho",
        "H�medo por dentro, con pelos por fuera. Comienza por la C. �De qu� se trata?",
        "Lo levanto cuando estoy contento, pero es m�s peque�o que el resto. �Qu� es?",
        "Tiene famosa memoria, gran tama�o y dura piel y la nariz m�s grandota, que en el mundo pueda haber",
        "En rincones y entre ramas mis redes voy construyendo, para que moscas incautas, en ellas vayan cayendo",
        "Orejas largas, rabo cortito, corro y salto muy ligerito",
        "Me llegan las cartas y no s� leer y, aunque me las trago, no mancho el papel. �Qu� es?",
        "Es peque�a como una pera, pero alumbra la casa entera. �Qu� es?",
        "Tengo teclas, pero no puedo tocar m�sica. Tengo letras, pero no puedo hablar. �Qu� soy?",
        "�Qui�n all� en lo alto en las ramas mora y all� esconde, avara, todo lo que roba?"
    };

    private List<string> respuestas = new List<string>
    {
        "vaca","coco","dedo pulgar","elefante","ara�a","conejo","buzon","bombilla","teclado","ardilla"
    };

    // Start is called before the first frame update
    void Start()
    {
        MostrarAcertijoRandom();

        // Suscribir la funci�n ComprobarRespuesta a la detecci�n de la tecla "Enter"
        respuestaInput.onSubmit.AddListener(delegate { ComprobarRespuesta(); });


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MostrarAcertijoRandom()
    {
        int indiceRandom = Random.Range(0, acertijos.Count);
        acertijoText.text = acertijos[indiceRandom];
    }

    public void ComprobarRespuesta()
    {
        string respuestaUsuario = respuestaInput.text.ToLower(); // Convertir a min�sculas para comparaci�n sin distinci�n entre may�sculas y min�sculas

        if (respuestaUsuario == respuestas[0] && acertijoText.text== "Por un caminito, va caminando un bicho. El nombre del bicho ya te lo he dicho")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
            // Aqu� puedes realizar acciones adicionales si la respuesta es correcta
        } else if (respuestaUsuario == respuestas[1] && acertijoText.text == "H�medo por dentro, con pelos por fuera. Comienza por la C. �De qu� se trata?")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[2] && acertijoText.text == "Lo levanto cuando estoy contento, pero es m�s peque�o que el resto. �Qu� es?")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[3] && acertijoText.text == "Tiene famosa memoria, gran tama�o y dura piel y la nariz m�s grandota, que en el mundo pueda haber")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[4] && acertijoText.text == "En rincones y entre ramas mis redes voy construyendo, para que moscas incautas, en ellas vayan cayendo")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[5] && acertijoText.text == "Orejas largas, rabo cortito, corro y salto muy ligerito")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[6] && acertijoText.text == "Me llegan las cartas y no s� leer y, aunque me las trago, no mancho el papel. �Qu� es?")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[7] && acertijoText.text == "Es peque�a como una pera, pero alumbra la casa entera. �Qu� es?")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        } else if (respuestaUsuario == respuestas[8] && acertijoText.text == "Tengo teclas, pero no puedo tocar m�sica. Tengo letras, pero no puedo hablar. �Qu� soy?")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        }else if (respuestaUsuario == respuestas[9] && acertijoText.text == "�Qui�n all� en lo alto en las ramas mora y all� esconde, avara, todo lo que roba?")
        {
            acertijoText.text = "�Correcto!, has acertado el acertijo";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("Muy bien, sigue as�");
        }
        else
        {
            acertijoText.text = "�Incorrecto!, no has acertado el acertijo :(";
            botonReinicio.gameObject.SetActive(true);
            respuestaInput.gameObject.SetActive(false);
            Debug.Log("No has acertado");
            // Aqu� puedes realizar acciones adicionales si la respuesta es incorrecta
        }

        // Limpiar el campo de entrada
        respuestaInput.text = "";

        // Mostrar un nuevo acertijo despu�s de cada respuesta
        //MostrarAcertijoRandom();

    }

    public void BotonReinicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

