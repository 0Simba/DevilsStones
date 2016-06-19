using UnityEngine;
using System.Collections;

public class GeneralConfig : MonoBehaviour {

    static public GeneralConfig instance;

    public BigPistolShotConfig bigPistolShotConfig;
    public PowderKegConfig     powderKegConfig;
    public SwapConfig          swapConfig;
    public SwordDashInConfig   swordDashInConfig;

    

    void Start () {
        instance = this;
    }
}