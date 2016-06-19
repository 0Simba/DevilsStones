using UnityEngine;
using System.Collections;

public class GeneralConfig : MonoBehaviour {

    static public GeneralConfig instance;

    public BigPistolShotConfig bigPistolShotConfig;
    public PowderKegConfig     powderKegConfig;
    public SwapConfig          swapConfig;

    

    void Start () {
        instance = this;
    }
}