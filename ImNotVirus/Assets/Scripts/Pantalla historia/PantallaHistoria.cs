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
        EmpezarDialogo();
        Invoke("SiguienteLinea", 4);
        Invoke("SiguienteLinea", 12);
        Invoke("SiguienteLinea",17);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarDialogo()
    {
        index = 0;
        StartCoroutine(EscribirLinea());
    }

    IEnumerator EscribirLinea()
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
            
            StartCoroutine(EscribirLinea());
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
