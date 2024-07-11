using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static UnityEvent DieEvent = new UnityEvent();
    [SerializeField] private int maxHp = 10;

    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;
    }

    public void ReceiveDamage(int amount)
    {
        currentHp -= amount;
        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        DieEvent.Invoke();
    }
}

