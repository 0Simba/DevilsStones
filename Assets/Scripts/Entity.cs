using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {

    void Start () {
        SetEntityTag();
    }


    public void SetEntityTag () {
        if (gameObject.layer != LayerMask.NameToLayer("Default") && gameObject.layer != LayerMask.NameToLayer("Entity")) {
            Debug.LogWarning("[Devil's stones] Entity.SetEntityTag -> Attached layer is different than default and entity, changed it for entity");
        }

        gameObject.layer = LayerMask.NameToLayer("Entity");
    }

}