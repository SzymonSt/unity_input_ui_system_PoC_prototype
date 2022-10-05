using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private bool isPaused;
    public void OnPause(bool isPaused)
    {
        if (isPaused)
        {
            this.isPaused = isPaused;
            MainController.Instance.DisablePlayerInputActionMap();
        }
        else
        {
            this.isPaused = isPaused;
            MainController.Instance.EnablePlayerInputActionMap();
        }
    }
    public void OnSwitch(GameObject button)
    {
        var textComponent = button.transform.GetChild(0)
                            .transform.GetComponent<TMP_Text>();
        var currentValue = textComponent.text;
        if(currentValue == "ON")
        {
            textComponent.SetText("OFF");
        }
        else
        {
            textComponent.SetText("ON");
        }
    }
}
