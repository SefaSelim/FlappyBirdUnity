using UnityEngine;
using UnityEngine.UI;

public class KeyboardController : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;


    public void ShowKeyboard()
    {
        if (keyboard == null || !keyboard.active)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
    }
}
