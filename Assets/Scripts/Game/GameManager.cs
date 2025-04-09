using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObjectGeneraters> gameObjectGeneraters = new List <GameObjectGeneraters>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            gameObjectGeneraters[0].Generater.ReGenerateObjects();
    }

}

[System.Serializable]
public class GameObjectGeneraters
{
    public GameObjectManager Generater;
}
