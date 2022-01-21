using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highlighter : MonoBehaviour
{
    [SerializeField] GameObject Highlight1;
    [SerializeField] GameObject Highlight2;
    [SerializeField] GameObject Highlight3;
    int currentHighlight;
    public OVRInput.RawButton getNextHighlightButton1;
    public OVRInput.RawButton getNextHighlightButton11;
    public OVRInput.RawButton getNextHighlightButton2;
    public OVRInput.RawButton getNextHighlightButton21;
    public OVRInput.RawButton selectButton;
    float startTime;

    private void Start()
    {
        //Original Highlight will be Highlight2(Medium height)
        currentHighlight = 2;
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime >= .2)
        {
            if (OVRInput.Get(getNextHighlightButton1) || OVRInput.Get(getNextHighlightButton11))
            {
                GetNextHighlight();
            }
            else if (OVRInput.Get(getNextHighlightButton2) || OVRInput.Get(getNextHighlightButton21))
            {
                GetBackHighlight();
            }
            startTime = Time.time;
        }
        if (OVRInput.Get(selectButton))
        {
            PlayerPrefs.SetInt("Height", currentHighlight);
            LoadNewScene(1);
        }
    }
    private void GetBackHighlight()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        if (currentHighlight != 1)
        {
            currentHighlight -= 1;
        }
        else
        {
            currentHighlight = 3;
        }
        if (currentHighlight == 1)
        {
            Highlight1.SetActive(true);
        }
        if (currentHighlight == 2)
        {
            Highlight2.SetActive(true);
        }
        if (currentHighlight == 3)
        {
            Highlight3.SetActive(true);
        }
    }

    private void GetNextHighlight()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        if (currentHighlight != 3)
        {
            currentHighlight += 1;
        }
        else
        {
            currentHighlight = 1;
        }
        if(currentHighlight==1)
        {
            Highlight1.SetActive(true);
        }
        if (currentHighlight == 2)
        {
            Highlight2.SetActive(true);
        }
        if (currentHighlight == 3)
        {
            Highlight3.SetActive(true);
        }
    }
    public void LoadNewScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
