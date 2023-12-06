using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue2Script : MonoBehaviour
{
    public GameObject gato;
    //private LeverScript palanca;
    public GameObject dialogue;
    public TextMeshProUGUI text;
    public string[] lines;
    public float tiempoEspera = 0.07f;
    private int index;
    private bool mensaje;

    private void Comprobar()
    {
        if(PlayerPrefs.GetInt("Palanca")==2){
            gato.gameObject.SetActive(false);
        }
        
        dialogue.gameObject.SetActive(false);
        text.text="";
        index=0;
    }

    void Start()
    {
        Invoke("Comprobar",0.001f);
        
        /*if(PlayerPrefs.GetInt("Palanca")==2){
            gato.gameObject.SetActive(false);
        }
        
        dialogue.gameObject.SetActive(false);
        text.text="";
        index=0;*/
    }


    void Update()
    {
        if(mensaje){
            if(Input.GetKeyDown(KeyCode.E) && index < lines.Length-2)
            {
                StopAllCoroutines();
                index++;
                StartCoroutine(WriteLine());
            }
    
            /*if(index==lines.Length-1 && palanca.active)
            {
                Despedida();
            }*/
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mensaje = true;
            dialogue.gameObject.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(WriteLine());
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            mensaje = false;
            dialogue.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }

    IEnumerator WriteLine()
    {
        Debug.Log("Se escribe el texto " +  index);
        
        text.text="";

        foreach(char letter in lines[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    public void Despedida()
    {
        Debug.Log("Despedida");
        StopAllCoroutines();
        index++;
        StartCoroutine(WriteLine());
    }
}
