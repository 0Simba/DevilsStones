using UnityEngine;
using System.Collections;

public class AreaDamage : MonoBehaviour {

    public float damagePerSeconds = 10;


    void Init (float damagePerSeconds) {
        this.damagePerSeconds = damagePerSeconds;
    }


    void OnTriggerStay (Collider other) {
        if (other.tag != "Entity") {
            return;
        }


        Entity entity = other.gameObject.GetComponent<Entity>();
        entity.Burn(damagePerSeconds);
    }
}