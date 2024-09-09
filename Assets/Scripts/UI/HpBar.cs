using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Image fill;
    [Space]
    [SerializeField] List<float> values = new List<float>();
    [SerializeField] List<Color32> colors = new List<Color32>();

    private float currentValue;
    private int colorIndex = -1;

    private void Start()
    {
        SetValue(1);
    }

    public void SetValue(float newValue)
    {
        currentValue = newValue;
        currentValue = Mathf.Clamp01(currentValue);
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        for(int i = values.Count - 1; i >= 0; i--)
        {
            if(currentValue >= values[i])
            {
                colorIndex = i;
                break;
            }
        }

        fill.color = colors[colorIndex];
        fill.fillAmount = currentValue;
        if (currentValue != 1)
        {
            ((RectTransform)fill.transform).DOShakePosition(0.35f, 10);
        }
    }
}
