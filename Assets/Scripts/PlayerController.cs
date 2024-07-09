using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.position = transform.position + new Vector3(1,0,0);

        gameObject.tag = "Player";
        gameObject.layer = 1;


    }

}
