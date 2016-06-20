using UnityEngine;
using System.Collections;

[System.Serializable]
public class NumberRange {

    public int min;
    public int max;

    public int RandomPick () {
        return Random.Range(min, max);
    }
}