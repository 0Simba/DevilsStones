using UnityEngine;
using System.Collections;


public class Player : Entity {

    new protected void Awake () {
        base.Awake();
        gameObject.AddComponent<GoToOnClick>();
    }


    new protected void Start () {
        base.Start();
        EventBus.EmitPlayerAdded(this);
    }


}