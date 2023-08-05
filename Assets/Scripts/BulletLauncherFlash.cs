using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncherFlash : MonoBehaviour
{
    bool GoingDown;
    MeshRenderer mr;
    Color color;
    Color MaterialColor;
    // Start is called before the first frame update
    void Start()
    {
        mr = this.GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void /*Fixed*/Update()
    {
        mr.material.color = MaterialColor;
        if (color.a*255 >= 250 || GoingDown)
        {
            print(color.a * 255);
            color.a -=.01f;
            
            GoingDown = true;
            MaterialColor.a = color.a;
        }
        if (color.a*255 <= 0 || !GoingDown)
        {
            print(color.a*255);
            color.a += .01f;
            GoingDown = false;
            mr.material.color = color;
        }

    }
}
