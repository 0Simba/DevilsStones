using UnityEngine;
using System.Collections;

[System.Serializable]
public class NumberRange {

    public int min;
    public int max;

    public int RandomPick () {
        return Random.Range(min, max);
    }

    public bool IsBetween (int value) {
        return (value >= min && value < max);
    }
}