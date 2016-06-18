using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldLifeBarHUD : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/

    static public List<WorldLifeBar> list;



    /*=====================================
    =            Instance part            =
    =====================================*/

    public GameObject parentCanvas;
    public GameObject lifeBarPrefab;


    void Awake () {
        list = new List<WorldLifeBar>();
        EventBus.entitySpawned += AddLifeBar;
        EventBus.entityDied    += RemoveLifeBar;
    }


    void Update () {
        for (int i = 0; i < list.Count; ++i) {
            list[i].Update();
        }
    }


    void AddLifeBar (Entity entity) {
        if (!entity.life.renderPoint) {
            return;
        }

        GameObject lifeBar = Instantiate(lifeBarPrefab) as GameObject;
        lifeBar.transform.SetParent(parentCanvas.transform);

        list.Add(new WorldLifeBar(entity, entity.life.renderPoint, lifeBar));
    }


    void RemoveLifeBar (Entity entity) {
        if (!entity.life.renderPoint) {
            return;
        }

        WorldLifeBar worldLifeBar = GetWorldLifeBar(entity);

        if (worldLifeBar != null) {
            list.Remove(worldLifeBar);
            Destroy(worldLifeBar.lifeBar);
        } 
    }


    WorldLifeBar GetWorldLifeBar (Entity entity) {
        for (int i = 0; i < list.Count; ++i) {
            if (list[i].entity == entity) {
                return list[i];
            }
        }

        return null;
    }
}