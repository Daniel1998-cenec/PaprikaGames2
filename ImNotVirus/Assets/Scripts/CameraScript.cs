using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1, -1);
    }
}
