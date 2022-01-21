using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int score;
    TextMeshProUGUI ScoreText;
    TextMeshProUGUI StreakText;
    TextMeshProUGUI StreakTitleText;
    bool AlreadyFaded=true;
    //TextMeshProUGUI dbgText;
    public int streakNum;
    public int newStreakNum;
    public bool streakBool = false;
    public void Start()
    {
        newStreakNum = 20;
        //dbgText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshProUGUI>();
        StreakText = GameObject.Find("StreakText").GetComponent<TextMeshProUGUI>();
        StreakTitleText = GameObject.Find("StreakTextTitle").GetComponent<TextMeshProUGUI>();
        
        score = 0;
        ScoreText = GameObject.Find("ScorePointText").GetComponent<TextMeshProUGUI>();
    }

    public void addScore(int addedScore) {
        streakBool = false;
        score += addedScore;
        this.GetComponent<AudioSource>().Play();
        ScoreText.text = "Score: " + score.ToString();
    }

    private void FixedUpdate()
    {
        StreakText.text = streakNum.ToString();
        GameObject sDPT = GameObject.Find("subtractDeathPointText");
        GameObject sDPT2 = GameObject.Find("subtractDeathPointText2");
        GameObject dw = GameObject.Find("DeathWall");
        if (streakNum != 0 && streakNum % 15 == 0 && sDPT.GetComponent<TextMeshProUGUI>().enabled == false)
        {
            
                dw.GetComponent<DeathPointCounter>().SubtractPoint();

            if (dw.GetComponent<DeathPointCounter>().deathPoints == 0 && !streakBool)
            {
                score += 1000;
                ScoreText.text = "Score: " + score.ToString();
                sDPT2.GetComponent<TextMeshProUGUI>().enabled = true;
                sDPT2.GetComponent<textGoDownScreen>().scrollon = true;
                streakBool = true;
            }
            else
            {
                sDPT.GetComponent<TextMeshProUGUI>().enabled = true;
                sDPT.GetComponent<textGoDownScreen>().scrollon = true;
            }
        }
            if (score > 20000)
        {
            GameObject.Find("GameManager").GetComponent<BallSpawner>().highpointbool = true;
        }
        if (streakNum >= 2)
        {
            if (!AlreadyFaded)
            {
                StartCoroutine(FadeTextToFullAlpha(1f, StreakText.GetComponent<TextMeshProUGUI>()));
                StartCoroutine(FadeTextToFullAlpha(1f, StreakTitleText.GetComponent<TextMeshProUGUI>()));
                AlreadyFaded = true;
            }

        }
        else
        {
            if (AlreadyFaded)
            {
                StartCoroutine(FadeTextToZeroAlpha(1f, StreakText.GetComponent<TextMeshProUGUI>()));
                StartCoroutine(FadeTextToZeroAlpha(1f, StreakTitleText.GetComponent<TextMeshProUGUI>()));
                AlreadyFaded = false;
            }
        }
    }

    //public void DebugOnCanvas(string Text)
    //{
    //     dbgText.text = Text.ToString();
    // }
    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }
    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
