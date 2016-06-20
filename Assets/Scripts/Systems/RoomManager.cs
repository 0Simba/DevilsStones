using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    void Awake () {
        gameObject.AddComponent<RoomLoader>();
    }


    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Generate();
        }
    }


    void Generate () {
        RoomData roomData = RoomCreator.CreateOnce();
        RoomLoader.Load(roomData);
    }
}