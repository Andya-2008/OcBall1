using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetPosHandler : MonoBehaviour
{
    public OVRInput.RawButton getPosButton;
    [SerializeField] GameObject PlayerController;
    [SerializeField] Transform HeadsetPos;
    [SerializeField] Transform ResetSpawnPoint;
    TextMeshProUGUI dbgText;
    // Start is called before the first frame update
    void Start()
    {
        dbgText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(getPosButton))
        {
            ResetPos();
        }
    }
    public void ResetPos()
    {
        
        PlayerController.transform.position = new Vector3(PlayerController.transform.position.x+(ResetSpawnPoint.position.x-HeadsetPos.position.x),PlayerController.transform.position.y+ (ResetSpawnPoint.position.y - HeadsetPos.position.y), PlayerController.transform.position.z+ (ResetSpawnPoint.position.z - HeadsetPos.position.z));
        
        PlayerController.transform.rotation = Quaternion.identity;
    }
    private void DebugOnCanvas(string dbugText)
    {
        dbgText.text = dbugText;
    }
}
