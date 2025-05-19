using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpenClose : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    Button menuButton;

    private void Start()
    {
        menuButton = GetComponent<Button>();
    }

    public void OnButtonClick()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }

}
