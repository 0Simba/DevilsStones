using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    static public Player instance;
    
    void Awake () {
        instance = this;
    }   
}