using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PipesHolder;
    public GameObject[] Pipes;

    [SerializeField]
    int totalPipes = 0;
    [SerializeField]
    int correctedPipes = 0;

    public GameObject WinText;

    public Button botonSalir;

    public bool fin;

    // Start is called before the first frame update
    void Start()
    {
        WinText.SetActive(false);
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];

        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void correctMove()
    {
        correctedPipes += 1;

        Debug.Log("correct Move");

        if(correctedPipes == totalPipes)
        {
            Debug.Log("You win!");
            fin=true;
            WinText.SetActive(true);
            botonSalir.gameObject.SetActive(true);

            if(PlayerPrefs.GetInt("Electricidad1")!=2)
            {
                PlayerPrefs.SetInt("Electricidad1",2);
                PlayerPrefs.SetInt("Refranes",1);
            }else{
                PlayerPrefs.SetInt("Electricidad2",2);
                PlayerPrefs.SetInt("TresEnRaya",1);
                PlayerPrefs.SetInt("PiedraPapelTijeras",1);
            }
        }
    }

    public void wrongMove()
    {
        correctedPipes -= 1;
    }

    public void Salir()
    {
        SceneManager.LoadScene("Nivel1");
    }
}
