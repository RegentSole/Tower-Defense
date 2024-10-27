using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public int timerSeconds;
    public Image clockImage;
    public TMP_Text counterText;
    public Button button;
    private Coroutine _timerCoroutine;

    /*private void Update()
    {
       //StopAllCoroutines();
        if (!clockImage.enabled) return;

        clockImage.fillAmount -= Time.deltaTime * timerSeconds / 100.0f;

        if (clockImage.fillAmount <= 0.0f)
        {
            ResetTimer();
            UpdateCounter();
        }
    }/**/

    private void ResetTimer()
    {
        clockImage.fillAmount = 1.0f;
        clockImage.enabled = true; //false или true
    }

    public void StartTimer()
    {
        StopAllCoroutines();
        _timerCoroutine = StartCoroutine(RunTimer());
    }

    public IEnumerator RunTimer()
    {
        for (float t = 1.0f; t >= 0.0f; t -= Time.deltaTime * timerSeconds / 100.0f)
        {
            clockImage.fillAmount = t;
            yield return new WaitForEndOfFrame();
        }
    
        ResetTimer();
        UpdateCounter();
    
    }

    private void UpdateCounter()
    {
        int currentCount;
        if (int.TryParse(counterText.text, out currentCount))
        {
            counterText.text = (currentCount + 1).ToString();
        }
        else
        {
            Debug.LogError("Invalid text format in counterText field.");
        }
    }
}