using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayPauseWidget : MonoBehaviour
{
    private string prefix;
    private string newText;
    private bool isPaused;
    void Start()
    {
        prefix = "Press space to: ";
        isPaused = MainController.Instance.isGamePaused;
        UpdateText();
    }
    public void OnPause(bool isPaused)
    {
        this.isPaused = isPaused;
        UpdateText();
    }
    private void UpdateText()
    {
        string value;
        if (isPaused)
        {
            value = "Play";
        }
        else
        {
            value = "Pause";
        }
        newText = string.Concat(prefix, value);
        this.gameObject.transform.GetComponent<TMP_Text>()
                                 .SetText(newText);
    }
}
