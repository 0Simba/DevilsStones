using UnityEngine;
using System.Collections;

public class DoorTeleporter : MonoBehaviour {

    int neighbour = 0;

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            TeleportPlayer();
        }
    }


    public void TeleportPlayer () {
        EventBus.EmitRoomTeleported(neighbour);
    }
}