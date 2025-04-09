using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 CurrentAngle;
    public Vector3 RotateAngle;
    public float RotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentAngle.x < RotateAngle.x)
        {
            //CurrentAngle.x = RotateAngle.x;
            CurrentAngle.x =  Mathf.Lerp(CurrentAngle.x, RotateAngle.x, 1/RotateSpeed);
        }
        

        gameObject.transform.localRotation = Quaternion.Euler(CurrentAngle);
    }
}
