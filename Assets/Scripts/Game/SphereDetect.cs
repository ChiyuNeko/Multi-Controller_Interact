using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereDetect : MonoBehaviour
{
    public GameObjectManager gameObjectManager;
    public string TagName;
    public bool  isTriggered;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == TagName)
        {
            gameObjectManager.DestroyObject(this.gameObject);
        }
    }

}
