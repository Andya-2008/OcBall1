using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLength__Power : MonoBehaviour
{
    [SerializeField] Transform Sphere1;
    [SerializeField] Transform Sphere2;
    [SerializeField] float changeAmount;
    public void OnEnable()
    {
        Sphere1.localScale += new Vector3(changeAmount,changeAmount,changeAmount);
        Sphere2.localScale += new Vector3(changeAmount, changeAmount, changeAmount);
        this.gameObject.GetComponent<PowerScript>().DoneWithPower();
    }
}
