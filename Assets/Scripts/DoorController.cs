using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] float interactRange = 1;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    PlayerController playerController;

    bool playerInRange = false;
    bool doorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (!doorOpen)
        {
            if (Mathf.Abs(playerController.transform.position.x - transform.position.x) <= interactRange)
            {
                if (!playerInRange)
                {
                    spriteRenderer.DOColor(Color.yellow, 1.0f);
                    playerInRange = true;
                }
            }
            else
            {
                ResetDoor();
            }

            if (Input.GetKey(KeyCode.E) && !doorOpen)
            {
                doorOpen = true;
                animator.SetTrigger("OpenDoor");
                ResetDoor();
            }
        }       
    }

    private void ResetDoor()
    {
        spriteRenderer.color = Color.white;
        spriteRenderer.DOKill();
        playerInRange = false;
    }
}
