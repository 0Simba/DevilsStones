using UnityEngine;
using System.Collections;

public class PlayerLifeBar : LifeBar {


    void Awake () {
        EventBus.playerAdded += LinkToPLayer;
    }


    void OnDestroy () {
        EventBus.playerAdded -= LinkToPLayer;
    }


    void LinkToPLayer (Entity player) {
        attachedLife = player.life;
    }

}