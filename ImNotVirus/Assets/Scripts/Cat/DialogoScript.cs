using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogoScript : MonoBehaviour
{

    public List<GameObject> dialogo;
    public GameObject info;
    private int i;

    public bool infoHabilitada;
    public bool mostrarInfoHabilitada;

    void Start()
    {
        i=0;

        info.gameObject.SetActive(false);

        for(int a=0; a<dialogo.Count;a++)
        {
          dialogo[a].gameObject.SetActive(false);   
        }
    }

    void Update()
    {
        if(infoHabilitada && Input.GetKeyDown(KeyCode.E))
            {
                i++;
                dialogo[i].gameObject.SetActive(true);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        infoHabilitada=true;
        if(collision.CompareTag("Player"))
        {
            info.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infoHabilitada=false;
        if(collision.CompareTag("Player"))
        {
            info.gameObject.SetActive(false);
            dialogo[i].gameObject.SetActive(false);
        }
    }


}
