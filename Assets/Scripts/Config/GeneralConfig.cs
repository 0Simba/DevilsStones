using UnityEngine;
using System.Collections;

public class GeneralConfig : MonoBehaviour {

    static public GeneralConfig instance;

    public BigPistolShotConfig bigPistolShotConfig;

    

    void Start () {
        instance = this;
    }
}