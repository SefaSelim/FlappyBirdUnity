using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RemoveEvent : MonoBehaviour
{
    [SerializeField] GameObject Button;

    public void Remove()
    {
        Button.SetActive(false);
    }
}
