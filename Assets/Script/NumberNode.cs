using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberNode : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private GameObject display;
    [SerializeField] private GameObject transmitter;





    public void ChangeNumber(int addNumber)
    {
        number += addNumber;
        display.GetComponent<TextMeshPro>().text = number.ToString();
    }
}
