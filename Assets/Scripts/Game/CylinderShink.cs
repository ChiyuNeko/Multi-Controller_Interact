using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderShink : MonoBehaviour
{
    public GameObjectManager gameObjectManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScaleRecover();
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
    public void ScaleRecover()
    {
        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.one * gameObjectManager.Scale, 1 / gameObjectManager.ShinkSpeed / 10);
    }
}
