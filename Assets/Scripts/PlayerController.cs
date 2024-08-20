using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static UnityEvent DieEvent = new UnityEvent();
    [SerializeField] private int maxHp = 10;
    [SerializeField] private float movementSpeed = 10;

    private int currentHp;

    private Vector2 moveAmount;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        transform.Translate(moveAmount * movementSpeed * Time.deltaTime);
    }

    public void ReceiveDamage(int amount)
    {
        currentHp -= amount;
        if(currentHp <= 0)
        {
            Die();
        }
        UIManager.Instance.UpdateHpBar((float)currentHp / maxHp);
    }

    private void Die()
    {
        gameObject.SetActive(false);
        DieEvent.Invoke();
    }
}

