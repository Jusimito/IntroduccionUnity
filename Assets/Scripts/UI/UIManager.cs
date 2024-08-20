using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] HpBar hpBar;

    private static UIManager instance;
    public static UIManager Instance => instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void UpdateHpBar(float currentHp)
    {
        hpBar.SetValue(currentHp);
    }
}
