using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractScript : MonoBehaviour
{
    private PlayerScript player;
    private bool isInRange;
    //public bool locked;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactAction;

    void Start()
    {        
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (isInRange && PlayerPrefs.GetInt(gameObject.name)!=0)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }

            if(interactKey==KeyCode.None)
            {
                interactAction.Invoke();
            }
        }
        else if(isInRange && Input.GetKeyDown(interactKey) && PlayerPrefs.GetInt(gameObject.name)==0)
        {
            Debug.Log("Está bloqueado.");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    //una vez tenga todos los puzzles, hacer que esto se haga en la escena de cada uno de los puzzles antes de cargar la escena de nivel1,
    //para evitar que se cierre el juego sin hacer el puzzle y que lo dé por hecho.
    public void PuzzleHecho(GameObject puzzle)
    {
        PlayerPrefs.SetInt(puzzle.name,2);
    }

    //una vez tenga todos los puzzles, hacer que esto se haga en la escena de cada uno de los puzzles antes de cargar la escena de nivel1
    //para evitar que se cierre el juego sin hacer el puzzle y que lo dé por hecho.
    public void Unlock(GameObject objectToUnlock)
    {
        PlayerPrefs.SetInt(objectToUnlock.name,1);
        Debug.Log("Se ha desbloqueado " + objectToUnlock.name);
    }

    public void CambiarEscena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Se ha cambiado a la escena " + sceneName);
    }
    
}
