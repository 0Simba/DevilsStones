using UnityEngine;
using System.Collections;

public class GeneralConfig : MonoBehaviour {

    static public GeneralConfig instance;

    /*=====  Pirates  ======*/

    public BigPistolShotConfig     bigPistolShotConfig;
    public PowderKegConfig         powderKegConfig;
    public SwapConfig              swapConfig;
    public SwordDashInConfig       swordDashInConfig;
    public SimplePistolShootConfig simplePistolShootConfig;



    /*=====  Enemies  ======*/
    
    public ImpConfig impConfig;



    /*=====  Rooms And Dungeon ======*/

    public DungeonConfig     dungeonConfig;
    public RoomCreatorConfig roomCreatorConfig;



    void Awake () {
        instance = this;
    }
}