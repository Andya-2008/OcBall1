using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textGoDownScreen : MonoBehaviour
{
    [SerializeField] float speed = 0;
    float startTime;
    public bool scrollon = false;
    [SerializeField] int scrollspeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (scrollon && this.transform.position.y >= -235)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - scrollspeed, this.transform.position.z);

        }
        else if (this.transform.position.y < -235) {
            scrollon = false;
            this.transform.position = new Vector3(this.transform.position.x, 235, this.transform.position.z);
            this.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }

}
