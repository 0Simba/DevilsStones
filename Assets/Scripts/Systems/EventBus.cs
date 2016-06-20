using UnityEngine;
using System.Collections;

public class EventBus : MonoBehaviour {

    public delegate void FloatMethod (float value);
    public delegate void EntityMethod (Entity entity);

    static public event FloatMethod overCostSpellCasted;
    static public void EmitOverCostSpellCasted (float a) { overCostSpellCasted(a); }


    static public event EntityMethod entitySpawned;
    static public void EmitEntitySpawned (Entity a) { entitySpawned(a); }


    static public event EntityMethod entityDied;
    static public void EmitEntityDied (Entity a) { entityDied(a); }


    static public event EntityMethod playerAdded;
    static public void EmitPlayerAdded (Entity a) { playerAdded(a); }
}