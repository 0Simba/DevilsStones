using UnityEngine;
using System.Collections;

public class Room {

    public Vector3       position;
    public Vector3[]     neighbors;
    public RoomGeography roomGeography;


    public Room (Vector3 position) {
        this.position  = position;
    }


    public void Load () {
        if (roomGeography == null) {
            Generate();
        }

        RoomLoader.Load(roomGeography);
        RoomEnemies.CreateOnce();
    }


    public void Generate () {
        RoomGeography roomGeography = RoomGeography.CreateOnce();
    }
}