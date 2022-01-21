using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShieldMaker : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] TextMeshProUGUI DebugText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug(("Shield collided with " + other).ToString());
        if(other.gameObject.name.Contains("Sphere"))
        {
            FormShield();
        }
    }

    void OnTriggerExit(Collider other)
    {
        UnFormShield();
    }


    public void FormShield()
    {
        Shield.SetActive(true);
    }

    public void UnFormShield()
    {
        Shield.SetActive(false);
    }
    /*private void Debug(string dbugText)
    {
        DebugText.text = dbugText;
    }*/
}
