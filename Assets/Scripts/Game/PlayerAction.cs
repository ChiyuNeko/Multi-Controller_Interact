using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public OVRInput.Button LasersSwitchBtn;
    public GameObject[] Lasers;
    public int LasersIndex = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LasersSwitch();
    }
    public void LasersSwitch()
    {
        if(OVRInput.GetDown(LasersSwitchBtn))
        {
            Lasers[LasersIndex].SetActive(false);
            LasersIndex++;
            if(LasersIndex > Lasers.Length - 1)
            {
                LasersIndex = 0;
            }
            Lasers[LasersIndex].SetActive(true);
        }
    }
}
