using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractScript : MonoBehaviour
{
    private bool isInRange;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private UnityEvent interactAction;
    void Start()
    {
        
    }

    void Update()
    {
        if (isInRange)
        {
            /*if (gameObject.CompareTag("Hide"))
            {
                //Invoke(GameObject.SetGameObjectsActive();
            }*/

            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }

            if(interactKey==KeyCode.None)
            {
                interactAction.Invoke();
            }
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

    
}
