using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderShink : MonoBehaviour
{
    public OVRInput.Button TriggerButton;
    public GameObjectManager gameObjectManager;
    public bool IsSphere = false;
    public bool IsShink = false;
    void Start()
    {
        // if(gameObject.tag == "Plane")
        // {
        //     TriggerButton = OVRInput.Button.PrimaryIndexTrigger;
        // }
        // if(gameObject.tag == "Cylinder")
        // {
        //     TriggerButton = OVRInput.Button.SecondaryIndexTrigger;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        //ScaleRecover();
        if(IsShink)
        {
            Shink();
        }
        // if(OVRInput.GetDown(TriggerButton))
        // {  
        //     Debug.Log("111111111111111111111111111111111111111111111111111111111111111");
        // }
    }
    public void DestroyObject(GameObject gameObject)
    {
        if(OVRInput.GetDown(TriggerButton) || IsSphere)
        {
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, 1/gameObjectManager.ShinkSpeed);
            if(!IsShink)
                IsShink = true;
            Debug.Log("111111111111111111111111111111111111111111111111111111111111111");
        }
    }

    public void Shink()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, 1/gameObjectManager.ShinkSpeed);
        if(gameObject.transform.localScale.x <= gameObjectManager.DisspearScale)
        {
            gameObjectManager.AllObjects.Remove(gameObject);
            Destroy(gameObject);
            gameObjectManager.ReGenerateObjects();
        }
    }
    // public void Shink(GameObject gameObject)
    // {
    //     gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, 1/gameObjectManager.ShinkSpeed);
    //     if(gameObject.transform.localScale.x <= gameObjectManager.DisspearScale)
    //     {
    //         gameObjectManager.AllObjects.Remove(gameObject);
    //         Destroy(gameObject);
    //         gameObjectManager.ReGenerateObjects();
    //     }
    // }
    public void ScaleRecover()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.one * gameObjectManager.Scale, 1 / gameObjectManager.ShinkSpeed / 10);
    }

}
