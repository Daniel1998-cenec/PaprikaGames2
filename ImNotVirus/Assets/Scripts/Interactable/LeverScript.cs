using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    Animator anim;
    bool active = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void activeLever()
    {
        anim.SetBool("Active", true);
        active = true;
        Debug.Log("Se ha activado la palanca.");
    }

    public void switchLever()
    {
        if (!active)
        {
            anim.SetBool("Active", true);
            active = true;
            Debug.Log("Ha activado el switch.");
        }
        else
        {
            anim.SetBool("Active", false);
            active = false;
            Debug.Log("Ha desactivado el switch.");

        }
    }
}
