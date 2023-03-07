using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private List<string> symbols = new List<string>();
    private int index = 0;
    void Start()
    {

        ShuffleSymbol();

    }

    public void ChangeTexts(string text)
    {
        GetComponent<TextMeshPro>().text = text;
    }

    public void ShuffleSymbol()
    {
        GetComponent<TextMeshPro>().text = symbols[index];
        index = ((index + 1) <symbols.Count) ? ++index : 0;
    }
}
