using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public TimerManager timerManager;
    public TMP_Text resourceText2;
    public Button button;

    public void OnClick()
    {
        if (int.Parse(resourceText2.text) < 5)
        {
            return;
        }
        if (int.Parse(resourceText2.text) >= 5 && !button.interactable)
    {
        button.interactable = true;
        timerManager.StartTimer();
    }
    else if (int.Parse(resourceText2.text) < 5)
    {
        button.interactable = false;
    }/**/
        //timerManager.StartTimer();
        RemoveResources(5);
    }

    private void RemoveResources(int resourcesToRemove)
    {
        // Код для уменьшения количества ресурсов
        int currentResource = int.Parse(resourceText2.text);
    resourceText2.text = (currentResource - resourcesToRemove).ToString();
    }
}
/**/