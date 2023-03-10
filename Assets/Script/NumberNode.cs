using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberNode : MonoBehaviour
{
    [SerializeField] public int value { get; private set; }
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject transmitter;

    public delegate void NodeAction(int number);
    public event NodeAction OnNumberChanged;
    public void ChangeNumber(int addNumber)
    {
        value += addNumber;
        display.GetComponent<TextMeshPro>().text = value.ToString();
        OnNumberChanged?.Invoke(value);
    }
}
