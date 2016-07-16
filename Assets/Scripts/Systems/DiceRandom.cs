using UnityEngine;
using System.Collections;

[System.Serializable]
public class DiceRandom {

    static public int Throw (int number, NumberRange facesRange) {
        int total = 0;

        for (int i = 0; i < number; ++i) {
            total += facesRange.RandomPick();
        }

        return total;
    }



    public int         number = 2;
    public NumberRange facesRange;


    public int Throw () {
        return Throw(number, facesRange);
    }
}