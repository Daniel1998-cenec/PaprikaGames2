using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    void Start()
    {
        if(gameObject.name.Equals("PuertaInicio") && PlayerPrefs.GetInt("Electricidad1")!=0)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
