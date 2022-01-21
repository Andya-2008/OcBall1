using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Mirror
{
    public class ResetSceneHandler : MonoBehaviour
    {
        public OVRInput.RawButton getSceneButton1;
        public OVRInput.RawButton getSceneButton2;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (OVRInput.Get(getSceneButton1) && OVRInput.Get(getSceneButton2))
            {
                LoadNewScene(0);
            }
        }
        public void LoadNewScene(int sceneNum)
        {
            SceneManager.LoadScene(sceneNum);
        }
    }
}

