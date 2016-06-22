using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    static public GameData instance;
    
    public int difficulty = 1;

    void Awake () {
        instance = this;
    }
}