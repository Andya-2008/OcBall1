using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "DeathBall")
        {
            LoadNewScene(0);
        }
    }
    public void LoadNewScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
