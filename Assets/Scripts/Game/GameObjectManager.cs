using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class GameObjectManager : MonoBehaviour
{
    public GameManager gameManager; 
    public Transform GeneraterPosition; // 整體重生點位置
    public List<GameObject> ObjectsPrefabs = new List<GameObject>();
    public List<GameObject> AllObjects = new List<GameObject>();
    public Vector2 GenerateZone;
    public Vector2 Distence;
    public float Scale;
    public Vector3 Offset;
    public float RandomOffset;
    public bool OnGround;

    void Start()
    {
        GeneraterPosition = this.transform;
        PreGenerateObjects();
        
    }

    void Update()
    {
        
    }

    public void PreGenerateObjects()
    {
        
        Vector3 GeneratePoint = GeneraterPosition.position;
        
        
        Vector3 RamdomPoint;
        for (int i = 0; i < GenerateZone.y; i++)
        {
            for(int j = 0; j < GenerateZone.x; j++)
            {
                RamdomPoint = new Vector3( Random.Range(-RandomOffset, RandomOffset), 0, Random.Range(-RandomOffset, RandomOffset));
                GameObject gameObject = Instantiate(ObjectsPrefabs[Random.Range(0, ObjectsPrefabs.Count)], GeneratePoint + RamdomPoint, Quaternion.identity, this.transform);
                gameObject.transform.localScale = Vector3.one * Scale;
                AllObjects.Add(gameObject);
                GeneratePoint.x += Distence.x;

                if(OnGround == true)
                {  
                    RaycastHit hit;
                    if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
                    {
                        if(hit.transform.tag == "Ground")
                            gameObject.transform.position = hit.point + Offset;
                    }
                }


            }
            GeneratePoint.z += Distence.y;
            GeneratePoint.x = gameObject.transform.position.x;
        }
    }
    public void DestroyObject(GameObject gameObject)
    {
        AllObjects.Remove(gameObject);
        Destroy(gameObject);
        ReGenerateObjects();
    }

    public void ReGenerateObjects()
    {
        int index = Random.Range(0, gameManager.gameObjectGeneraters.Count); 
        //Debug.Log("" + index);
        GameObjectGeneraters gameObjectGeneraters = gameManager.gameObjectGeneraters[index];
        GameObjectManager generater = gameObjectGeneraters.Generater;
        Vector3 GeneratePoint = generater.GeneraterPosition.position;
        List <GameObject> objectsPrefabs = generater.ObjectsPrefabs;
        float randomOffset = generater.RandomOffset;

        //隨機選擇物件生成器裡的其中一種，並取其數值
        
        GeneratePoint.z += Random.Range(0, generater.GenerateZone.y) * generater.Distence.y;
        GeneratePoint.x += Random.Range(0, generater.GenerateZone.x) * generater.Distence.x;
        GeneratePoint.y = generater.GeneraterPosition.position.y;
        Vector3 RamdomPoint = new Vector3( Random.Range(-randomOffset, randomOffset), 0, Random.Range(-randomOffset, randomOffset));
        GameObject gameObject = Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Count)], GeneratePoint + RamdomPoint, Quaternion.identity, generater.GeneraterPosition);
        gameObject.transform.localScale = Vector3.one * generater.Scale;
        
        if(generater.OnGround == true)
        {
            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "Ground")
                    gameObject.transform.position = hit.point + generater.Offset;
            }
        }
    }
    
    
}
