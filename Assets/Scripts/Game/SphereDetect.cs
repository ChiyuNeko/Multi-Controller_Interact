using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDetect : MonoBehaviour
{
    public GameObjectManager gameObjectManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
        {
            gameObjectManager.DestroyObject(gameObject);
        }
    }

}
