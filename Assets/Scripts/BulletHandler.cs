using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BulletHandler : MonoBehaviour
{
    int totalBulletNum = 3;
    [SerializeField] TextMeshProUGUI BulletText;
    [SerializeField] GameObject LeftHandFlash;
    [SerializeField] GameObject RightHandFlash;
    [SerializeField] GameObject PlayerBall;
    public OVRInput.RawButton LeftHandShoot;
    public OVRInput.RawButton RightHandShoot;
    [SerializeField] Transform LeftHandShootPos;
    [SerializeField] Transform RightHandShootPos;
    [SerializeField] Transform BallParent;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        LeftHandFlash.SetActive(false);
        RightHandFlash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BulletText.text = "Bullets: " + totalBulletNum.ToString();
        if (Time.time - startTime > 2)
        {
            if (OVRInput.GetDown(LeftHandShoot))
            {
                UseBullet("left");
            }
            if (OVRInput.GetDown(RightHandShoot))
            {
                UseBullet("right");
            }
            else if (OVRInput.GetUp(LeftHandShoot))
            {
                ShootBullet("left");
            }
            else if (OVRInput.GetUp(RightHandShoot))
            {
                ShootBullet("right");
            }
        }
    }
    public void AddBullet(int numOfBullets)
    {
        totalBulletNum += numOfBullets;
    }
    public void UseBullet(string Hand)
    {
        if (totalBulletNum > 0)
        {
            if (Hand == "left")
            {
                LeftHandFlash.SetActive(true);
            }
            else if (Hand == "right")
            {
                RightHandFlash.SetActive(true);
            }
            else
            {
                Debug.LogError("UseBullet on the script, 'Bullet Handler' doesn't correlate with a hand!");
            }
        }
    }
    public void ShootBullet(string Hand)
    {
        if (totalBulletNum > 0)
        {
            totalBulletNum -= 1;
            this.GetComponent<AudioSource>().Play();
            if (Hand == "left")
            {
                LeftHandFlash.SetActive(false);
                GameObject newPlayerBall = Instantiate(PlayerBall, LeftHandShootPos);
                newPlayerBall.transform.parent = BallParent;
            }
            else if (Hand == "right")
            {
                RightHandFlash.SetActive(false);
                GameObject newPlayerBall = Instantiate(PlayerBall, RightHandShootPos);
                newPlayerBall.transform.parent = BallParent;
            }

            else
            {
                Debug.LogError("ShootBullet on the script, 'Bullet Handler' doesn't correlate with a hand!");
            }
        }
    }
}