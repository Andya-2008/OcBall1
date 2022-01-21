using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class debugTest : MonoBehaviour
{
    TextMeshProUGUI dbgText;

    public void Start()
    {
        //dbgText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshProUGUI>();
        DebugOnCanvas("Hybrid Ball has been instantiated!");
        Debug.Log("Hybrid Ball has been instantiated!");
    }


    public void DebugOnCanvas(string Text)
    {
        //dbgText.text = Text.ToString();
    }
}
