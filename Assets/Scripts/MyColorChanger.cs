using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColorChanger : MonoBehaviour
{
    Color newColor;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newColor = new Color(
      Random.Range(0f, 1f),
      Random.Range(0f, 1f),
      Random.Range(0f, 1f)
      );
    }
}
