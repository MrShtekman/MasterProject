using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberNode : MonoBehaviour
{
    public int value = 0;
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject transmitter;

    public delegate void NodeAction(int number);
    public event NodeAction OnNumberChanged;

    public void Start()
    {
        display.GetComponent<TextMeshPro>().text = value.ToString();
    }

    //Change the value and invoke the event
    public void ChangeNumber(int addNumber)
    {
        value += addNumber;
        display.GetComponent<TextMeshPro>().text = value.ToString();
        OnNumberChanged?.Invoke(value);
    }
}
