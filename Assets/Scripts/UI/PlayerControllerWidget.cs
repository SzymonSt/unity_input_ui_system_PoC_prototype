using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerWidget : MonoBehaviour
{
    private string newText;
    private string prefix;
    private bool isEnabled;
    void Start()
    {
        prefix = "PlayerController: ";
        isEnabled = MainController.Instance.isPlayerControllerEnabled;
        UpdateText();
    }
    public void OnPlayerControllerStateSwitch(bool isEnabled)
    {
        this.isEnabled = isEnabled;
        UpdateText();
    }
    private void UpdateText()
    {
        newText = string.Concat(prefix, isEnabled.ToString());
        this.gameObject.transform.GetComponent<TMP_Text>()
                                 .SetText(newText);
    }
}
