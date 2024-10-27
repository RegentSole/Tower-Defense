using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeText; // Текстовое поле для отображения счетчика запусков
    public TMP_Text resourceText; // Текстовое поле для отображения количества ресурса
    public Image clockImage;
    
    private float timer = 0f;
    private int countdown = 0;
    private bool isTimerActive = false;
    private int resourceCounter = 0;
    

    void Start()
{
    timeText.text = "0";
    resourceText.text = "Ресурс: " + resourceCounter;
    
    // Создаем таймер
    InvokeRepeating("UpdateLine", 0f, 1f);
}

void UpdateLine()
{
    if (isTimerActive)
    {
        resourceCounter += 3;
        resourceText.text = "Ресурс: " + resourceCounter;
        
        if (resourceCounter >= 5 && !button.interactable)
        {
            button.interactable = true;
        }
    }
    else
    {
        if (resourceCounter > 0)
        {
            resourceCounter -= 5;
            resourceText.text = "Ресурс: " + resourceCounter;
            
            if (resourceCounter <= 0)
            {
                button.interactable = false;
            }
        }
    }
}

public void StartCountdown(int seconds)
{
    if (!isTimerActive)
    {
        isTimerActive = true;
        countdown = seconds;
        Debug.Log($"Начало обратного отсчета на {countdown} секунд");
        StartCoroutine(CountDown());
    }
}

IEnumerator CountDown()
{
    while (countdown > 0)
    {
        yield return new WaitForSeconds(1f);
        countdown--;
        timer++;
        timeText.text = Mathf.RoundToInt(timer).ToString();
        clockImage.fillAmount -= Time.deltaTime * countdown / 100.0f;
    }

    ResetTimer();
}

public void ResetTimer()
{
    isTimerActive = false;
    timer = 0f;
    timeText.text = "0";
    Debug.Log("Обратный отсчет завершен.");
}

#region Custom References
[SerializeField] private Button button;
#endregion
}