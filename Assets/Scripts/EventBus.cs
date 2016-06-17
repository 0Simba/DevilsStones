using UnityEngine;
using System.Collections;

public class EventBus : MonoBehaviour {

    public delegate void FloatMethod (float value);
    static public event FloatMethod overCostSpellCasted;
    static public void EmitOverCostSpellCasted (float a) { overCostSpellCasted(a); }
}