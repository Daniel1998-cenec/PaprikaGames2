using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public GameObject gato;
    public GameObject puerta;
    public GameObject dialogue;
    public TextMeshProUGUI text;
    public string[] lines;
    public float tiempoEspera = 0.07f;
    private int index;
    private bool mensaje;

    void Awake()
    {
        Comprobar();
    }

    private void Comprobar()
    {
        if(PlayerPrefs.GetInt("Comienzo")!=0){
            gato.gameObject.SetActive(false);
            puerta.gameObject.SetActive(false);
        }

        text.text="";
        dialogue.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }


    void Update()
    {
        if(mensaje)
        {
            dialogue.gameObject.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E) && index < lines.Length-1)
            {
                StopAllCoroutines();
                text.text="";
                index++;
                StartCoroutine(WriteLine());
            }
            else if(index==lines.Length-1)
            {
                PlayerPrefs.SetInt("Comienzo", 2);
            }
        }
        
        if(PlayerPrefs.GetInt("Comienzo")!=0)
        {
            puerta.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            mensaje = true;
            StartCoroutine(WriteLine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            mensaje = false;
            StopAllCoroutines();
            text.text="";
            dialogue.gameObject.SetActive(false);
            index = 0;
            
            gato.gameObject.SetActive(false);
            Debug.Log("El gato se fue.");
        }
    }

    IEnumerator WriteLine()
    {
        foreach(char letter in lines[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}
