using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObjectGeneraters> gameObjectGeneraters = new List <GameObjectGeneraters>();
    public Text AllObjectText;
    public Text CylinderText;
    public Text PlaneText;
    public Text SphereText;
    int AllObjectCounts;
    int CylinderCounts;
    int PlaneCounts;
    int SphereCounts;

    void Start()
    {

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            gameObjectGeneraters[0].Generater.ReGenerateObjects();
    }
    public void UpdateUI()
    {
        AllObjectCounts = 0;
        for (int i = 0; i < gameObjectGeneraters.Count; i++)
            AllObjectCounts += gameObjectGeneraters[i].Generater.AllObjects.Count;

        CylinderCounts = gameObjectGeneraters[0].Generater.AllObjects.Count;
        PlaneCounts = gameObjectGeneraters[1].Generater.AllObjects.Count;
        SphereCounts  = gameObjectGeneraters[2].Generater.AllObjects.Count;

        AllObjectText.text = "All Objects Count: " + AllObjectCounts;
        CylinderText.text = "Green Count: " + CylinderCounts;
        PlaneText.text = "Yellow Count: " + PlaneCounts;
        SphereText.text = "Red Count: " + SphereCounts;
    }
}

[System.Serializable]
public class GameObjectGeneraters
{
    public GameObjectManager Generater;
}
