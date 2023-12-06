using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(LickAnim());
    }


    void Update()
    {
        
    }


    private void Lick()
    {
        anim.SetBool("Lick", true);
        //Debug.Log("Gato se lame");
    }

    private void StopLick()
    {
        anim.SetBool("Lick", false);
        //Debug.Log("Gato se deja de lamer");
    }

    IEnumerator LickAnim()
    {
        while(true)
        {
            yield return new WaitForSeconds(10);
            Lick();
        }
    }
}
