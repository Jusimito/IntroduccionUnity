using System;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;

    TimeSpan timeSpan;
    public void UpdateCounter(float time)
    {
        timeSpan = TimeSpan.FromSeconds(time);
        textComponent.text = timeSpan.ToString("mm':'ss");
    }
}
