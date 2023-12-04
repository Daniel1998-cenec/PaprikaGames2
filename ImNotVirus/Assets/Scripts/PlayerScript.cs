using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float speed = 8f;

    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        Debug.Log("PlayerPrefs:\nPosicion X: " + PlayerPrefs.GetInt("xPos")
        + "\nPosicion Y: " + PlayerPrefs.GetInt("yPos")
        + "\nPalanca: " + PlayerPrefs.GetInt("Palanca")
        + "\nElectricidad1 " + PlayerPrefs.GetInt("Electricidad1")
        + "\nRefranes " + PlayerPrefs.GetInt("Refranes")
        + "\nElectricidad2 " + PlayerPrefs.GetInt("Electricidad2")
        + "\nTresEnRaya " + PlayerPrefs.GetInt("TresEnRaya")
        + "\nPiedraPapelTijeras " + PlayerPrefs.GetInt("PiedraPapelTijeras")
        + "\nAcertijos " + PlayerPrefs.GetInt("Acertijos")
        + "\nNumeros " + PlayerPrefs.GetInt("Numeros"));

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        
        anim.SetFloat("MoveX", moveX);
        anim.SetFloat("MoveY", moveY);

        if(moveX!=0 || moveY!=0)
        {
            anim.SetFloat("LastX",moveX);
            anim.SetFloat("LastY", moveY);
        }

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveDirection*speed;

    }
    
    public void checkPoint()
    {
        PlayerPrefs.SetFloat("xPos", transform.position.x);
        PlayerPrefs.SetFloat("yPos", transform.position.y);
        Debug.Log("Se ha guardado checkpoint en coords: " + transform.position.x + transform.position.y);
    }
    

}
