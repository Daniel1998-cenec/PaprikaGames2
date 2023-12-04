using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo2 : MonoBehaviour
{

    public TextMeshProUGUI text;
    public string[] lines;
    public float speed = 0.2f;
    private int index;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());

    }

    IEnumerator WriteLine()
    {
        foreach(char letter in lines[index].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
}
