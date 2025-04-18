using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    public Transform DeadZone;
    public GameObjectManager gameObjectManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y > DeadZone.position.y)
        {
            gameObjectManager.AllObjects.Remove(gameObject);
            gameObjectManager.ReGenerateObjects();
            Destroy(gameObject);
        }
        
    }
}
