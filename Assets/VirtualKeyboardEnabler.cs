using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VirtualKeyboardEnabler : MonoBehaviour
{
    public TNVirtualKeyboard TNvkKeyboard;
    vkEnabler vkEnabler;
    bool isActive = false;
    OnButtonClick onButtonClick;

    private void Start()
    {
        vkEnabler = GetComponent<vkEnabler>();
    }


    public void OnButtonClick()
    {
        if (!isActive)
        {
            vkEnabler.ShowVirtualKeyboard();
        }
        else
        {
            TNVirtualKeyboard.instance.HideVirtualKeyboard();
        }

        isActive = !isActive;
    }
}
