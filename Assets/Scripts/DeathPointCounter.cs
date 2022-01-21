using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DeathPointCounter : MonoBehaviour
{
    [SerializeField] List<GameObject> ballList = new List<GameObject>();
    [SerializeField] TextMeshProUGUI deathpointText;
    [SerializeField] GameObject DeathCanvas;
    [SerializeField] GameOverHandler gameOverHandler;
    [SerializeField] GameObject deathTextPar;
    //TextMeshProUGUI dbgText;

    public int deathPoints;
    // Start is called before the first frame update

    private void Start()
    {
        //dbgText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshProUGUI>();
    }
    private void FixedUpdate()
    {
        
    }
    public void AddPoint()
    {
        deathPoints += 1;
        this.GetComponent<AudioSource>().Play();
        deathTextPar.SetActive(true);
        deathpointText.text = "Deathpoints: " + deathPoints.ToString();

        if (deathPoints >= 5)
        {
            DeathCanvas.SetActive(true);
            foreach (GameObject Ball in ballList)
            {
                Destroy(Ball);
            }
            gameOverHandler.GetComponent<GameOverHandler>().enabled = true;

        }
    }
    public void SubtractPoint()
    {

        if (deathPoints > 0)
        {
            deathPoints -= 1;
        }
        if(deathPoints > 0)
        {
            deathTextPar.SetActive(true);
            deathpointText.text = "Deathpoints: " + deathPoints.ToString();
        }
        else
        {
            deathTextPar.SetActive(false);
        }
    }
}