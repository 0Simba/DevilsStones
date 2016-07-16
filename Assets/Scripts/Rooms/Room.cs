using UnityEngine;
using System.Collections;

public class Room {

    public Vector3   position;
    public Vector3[] neighbors;

    public Room (Vector3 position) {
        this.position  = position;
    }
}