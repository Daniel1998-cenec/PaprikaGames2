using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PantallaHistoria : MonoBehaviour
{
    public TextMeshProUGUI textoHistoria;
    public string[] lineas;
    public float velocidadTexto = 0.1f;
    int index;
    public Button botonContinuar;

    // Start is called before the first frame update
    void Start()
    {
        empezarDialogo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textoHistoria.text == lineas[index])
            {
                SiguienteLinea();
            }
            else
            {
                StopAllCoroutines();
                textoHistoria.text = lineas[index];
            }
        }
    }

    public void empezarDialogo()
    {
        index = 0;
        StartCoroutine(escribirLinea());
    }

    IEnumerator escribirLinea()
    {
        foreach (char letter in lineas[index].ToCharArray())
        {
            textoHistoria.text += letter;
            yield return new WaitForSeconds(velocidadTexto);
        }
    }

    public void SiguienteLinea()
    {
        if (index < lineas.Length - 1)
        {
            index++;
            textoHistoria.text = string.Empty;
            StartCoroutine(escribirLinea());
        }
        else
        {
            textoHistoria.gameObject.SetActive(false);
            botonContinuar.gameObject.SetActive(true);
        }
    }

    public void BotonContinuar()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
