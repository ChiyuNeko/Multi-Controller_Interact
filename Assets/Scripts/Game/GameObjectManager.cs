using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class GameObjectManager : MonoBehaviour
{
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
        PreGenerateObjects();
        
    }

    void Update()
    {
        
    }

    public void PreGenerateObjects()
    {
        Vector3 GeneratePoint =  gameObject.transform.position;
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
        Vector3 GeneratePoint =  this.gameObject.transform.position;
        GeneratePoint.z += Random.Range(0, GenerateZone.y) * Distence.y;
        GeneratePoint.x += Random.Range(0, GenerateZone.x) * Distence.x;
        Vector3 RamdomPoint = new Vector3( Random.Range(-RandomOffset, RandomOffset), 0, Random.Range(-RandomOffset, RandomOffset));
        GameObject gameObject = Instantiate(ObjectsPrefabs[Random.Range(0, ObjectsPrefabs.Count)], GeneratePoint + RamdomPoint, Quaternion.identity, this.transform);
        gameObject.transform.localScale = Vector3.one * Scale;
        
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
    
    
}
