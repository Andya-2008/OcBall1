using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPower : MonoBehaviour
{
    int PowerNum = 0;
    [SerializeField] List<Power> Powerups = new List<Power>();
    bool randomBool = true;
    // Start is called before the first frame update
    void Start()
    {
        
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
