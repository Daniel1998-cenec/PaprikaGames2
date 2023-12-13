using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fuente : MonoBehaviour
{
    public GameObject dialogue;
    public TextMeshProUGUI text;
    public string[] lines;
    public float tiempoEspera = 0.04f;
    private int index;
    private bool mensaje;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mensaje){
            if(Input.GetKeyDown(KeyCode.E) && index < lines.Length-2)
            {
                StopAllCoroutines();
                index++;
                StartCoroutine(WriteLine());
            
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&gameObject.activeInHierarchy)
        {
            mensaje = true;
            dialogue.gameObject.SetActive(true);

            StopAllCoroutines();
            StartCoroutine(WriteLine());
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player")&&gameObject.activeInHierarchy)
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
}
