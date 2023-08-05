using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPower : MonoBehaviour
{
    int PowerNum = 0;
    [SerializeField] List<PowerScript> Powerups = new List<PowerScript>();
    bool randomBool = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddThePower("");
        }
    }

    public void AddThePower(string power)
    {
        /*
        if(power == "Random" || power == "random")
        {
            randomBool = true;
        }
        else
        {
            randomBool = false;
        }
        if(randomBool)
        {*/
            PowerNum = Random.Range(0, Powerups.Count);
            Powerups[PowerNum].gameObject.SetActive(true);
        //}

    }
}
