using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserAndCloser : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thisTransform = this.transform.position;
        this.transform.position = new Vector3(thisTransform.x, thisTransform.y, thisTransform.z - speed / 20);
    }
}
