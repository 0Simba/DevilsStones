using UnityEngine;
using System.Collections;


public class Player : Entity {

    void Awake () {
        gameObject.AddComponent<GoToOnClick>();
    }


    new protected void Start () {
        base.Start();
        EventBus.EmitPlayerAdded(this);
    }


}