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
    [SerializeField] GameObject Tutorial;
    int currentHighlight;
    public OVRInput.RawButton getNextHighlightButton1;
    public OVRInput.RawButton getNextHighlightButton11;
    public OVRInput.RawButton getNextHighlightButton2;
    public OVRInput.RawButton getNextHighlightButton21;
    public OVRInput.RawButton getDownHighlightButton1;
    public OVRInput.RawButton getDownHighlightButton2;
    public OVRInput.RawButton getTutorialButton1;
    public OVRInput.RawButton getTutorialButton2;
    public OVRInput.RawButton selectButton;
    public bool tutorialBool;
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
                tutorialBool = false;
                GetNextHighlight();
            }
            else if (OVRInput.Get(getNextHighlightButton2) || OVRInput.Get(getNextHighlightButton21))
            {
                tutorialBool = false;
                GetBackHighlight();
            }
            else if(OVRInput.Get(getTutorialButton1) || OVRInput.Get(getTutorialButton2))
            {
                tutorialBool = true;
                GoTutorial();
            }
            else if (OVRInput.Get(getDownHighlightButton1) || OVRInput.Get(getDownHighlightButton2))
            {
                tutorialBool = false;
                if (currentHighlight != 1)
                {
                    currentHighlight -= 1;
                }
                else
                {
                    currentHighlight = 3;
                }
                GetNextHighlight();
            }
            startTime = Time.time;
        }
        if (OVRInput.Get(selectButton))
        {
            /*
            if (!tutorialBool)
            {
                PlayerPrefs.SetInt("Height", currentHighlight);
                LoadNewScene(2);
            }
            else
            {
                LoadNewScene(1);
            }
            */
            PlayerPrefs.SetInt("Height", currentHighlight);
            LoadNewScene(1);
        }
    }

    private void GoTutorial()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        Tutorial.SetActive(true);
    }

    private void GetBackHighlight()
    {
        Highlight1.SetActive(false);
        Highlight2.SetActive(false);
        Highlight3.SetActive(false);
        Tutorial.SetActive(false);
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
        Tutorial.SetActive(false);
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
