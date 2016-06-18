using UnityEngine;
using System.Collections;

public class SpellHelper : MonoBehaviour {

    static public bool CastedInRange (Vector3 casterPosition, float range) {
        if (!Mouse.isOverFloor) {
            return false;
        }

        return ((casterPosition - Mouse.floorPosition).magnitude <= range);
    }
}