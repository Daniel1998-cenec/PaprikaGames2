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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
    

}
