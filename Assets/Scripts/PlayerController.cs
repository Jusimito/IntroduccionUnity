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
    [SerializeField] private SpriteRenderer renderer;

    [SerializeField] private float jumpMaxHeight = 2f;
    [SerializeField] private AnimationCurve jumpCurve;

    private int currentHp;

    private Vector2 moveAmount;
    private bool jumping = false;

    private void Start()
    {
        currentHp = maxHp;
        jumping = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!jumping)
        {
            if (context.ReadValueAsButton())
            {
                jumping = true;
                StartCoroutine(JumpCoroutine());
            }
        }
    }

    private IEnumerator JumpCoroutine()
    {
        float time = 0;
        float startHeight = transform.position.y;

        while(time < 1)
        {
            time += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, startHeight + jumpCurve.Evaluate(time) * jumpMaxHeight, 0);
            yield return null;
        }

        time = 1;
        float topHeight = transform.position.y;

        while (time > 0)
        {
            time -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x, topHeight - (1 - jumpCurve.Evaluate(time)) * jumpMaxHeight, 0);
            yield return null;
        }

        yield return null;
        transform.position = new Vector3(transform.position.x, startHeight, 0);
        jumping = false;
    }



    Vector3 currentPosition;
    Vector3 targetPosition;

    private void Update()
    {
        if (GameManager.Instance.GameStarted)
        {
            currentPosition = transform.position;
            targetPosition = currentPosition + (new Vector3(moveAmount.x, moveAmount.y, 0) * movementSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(currentPosition, targetPosition, 0.5f);
        }
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

