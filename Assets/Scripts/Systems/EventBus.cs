using UnityEngine;
using System.Collections;

public class EventBus : MonoBehaviour {

    public delegate void FloatMethod  (float  value);
    public delegate void IntMethod    (int    value);
    public delegate void SpellMethod  (Spell  spell);
    public delegate void EntityMethod (Entity entity);

    static public event FloatMethod overCostSpellCasted;
    static public void EmitOverCostSpellCasted (float a) { overCostSpellCasted(a); }


    static public event EntityMethod entitySpawned;
    static public void EmitEntitySpawned (Entity a) { entitySpawned(a); }


    static public event EntityMethod entityDied;
    static public void EmitEntityDied (Entity a) { entityDied(a); }


    static public event EntityMethod playerAdded;
    static public void EmitPlayerAdded (Entity a) { playerAdded(a); }


    static public event SpellMethod spellAdded;
    static public void EmitSpellAdded (Spell spell) { spellAdded(spell); }


    static public event IntMethod difficultyChanged;
    static public void EmitDifficultyChanged (int a) { difficultyChanged(a); }


    static public event IntMethod roomTeleported;
    static public void EmitRoomTeleported (int a) { roomTeleported(a); }
}