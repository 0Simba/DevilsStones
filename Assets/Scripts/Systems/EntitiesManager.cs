using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EntitiesManager : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/

    static public List<Entity>[] listFromCamp;
    static public List<Entity>   list;


    static public Entity GetNearestOpponent (Entity from) {
        List<Entity> opponentsList = GetOpponentsList(from);
        return GetNearestEntity(from, opponentsList);
    }


    static public Entity GetNearestEntity (Entity from, List<Entity> entities) {
        if (entities.Count == 0) {
            return null;
        }

        TwoEntityRelation nearest = new TwoEntityRelation(from, entities[0]);

        for (int i = 1; i < entities.Count; ++i) {
            TwoEntityRelation next = new TwoEntityRelation(from, entities[i]);

            if (next.distance < nearest.distance) {
                nearest = next;
            }
        }

        return nearest.entityB;
    }


    static public List<Entity> GetOpponentsList (Entity from) {
        List<Entity> opponents = new List<Entity>();

        for (int i = 0 ; i < listFromCamp.Length; ++i) {
            if (i == (int) from.camp) {
                continue;
            }

            opponents.AddRange(listFromCamp[i]);
        }

        return opponents;
    }



    /*=====================================
    =            Instance part            =
    =====================================*/

    public int entitiesHeavyUpdatedPerFrame = 5;

    private int heavyUpdateCursor = 0;

    void Awake () {
        InitListFromCamp();
        list = new List<Entity>();

        EventBus.entitySpawned += AddEntity;
        EventBus.entityDied    += RemoveEntity;
    }


    void InitListFromCamp () {
        int campLength = Enum.GetNames(typeof(Entity.Camp)).Length;

        listFromCamp = new List<Entity>[campLength];

        for (int i = 0; i < campLength; ++i) {
            listFromCamp[i] = new List<Entity>();
        }
    }


    public void AddEntity (Entity entity) {
        int campIndex = (int) entity.camp;

        listFromCamp[campIndex].Add(entity);
        list.Add(entity);
    }


    public void RemoveEntity (Entity entity) {
        int campIndex = (int) entity.camp;

        listFromCamp[campIndex].Remove(entity);
        list.Remove(entity);
        heavyUpdateCursor--;
    }


    void Update () {
        CallHeavyUpdates();
    }


    void CallHeavyUpdates () {
        if (list.Count == 0) {
            return;
        }
        if (entitiesHeavyUpdatedPerFrame <= list.Count) {
            CallAllHeavyUpdates();
        }
        else {
            CallNextHeavyUpdates();
        }
    }


    void CallNextHeavyUpdates () {
        int heavyUpdateDone = 0;

        while (heavyUpdateDone < entitiesHeavyUpdatedPerFrame) {
            heavyUpdateDone++;

            CallNextHeavyUpdate();
        }
    }


    void CallNextHeavyUpdate () {
        if (heavyUpdateCursor < 0) {
            heavyUpdateCursor = list.Count - 1;
        }

        list[heavyUpdateCursor].HeavyUpdate();

        heavyUpdateCursor--;
    }


    void CallAllHeavyUpdates () {
        for (int i = list.Count - 1; i >= 0; --i) {
            list[i].HeavyUpdate();
        }
    }
}