using UnityEngine;
using System.Collections;

public class WorldLifeBar {

    public Entity     entity;
    public Transform  point;
    public GameObject lifeBar;


    public WorldLifeBar (Entity entity, Transform point, GameObject lifeBar) {
        this.entity  = entity;
        this.point   = point;
        this.lifeBar = lifeBar;

        LifeBar lifeBarScript = lifeBar.GetComponent<LifeBar>();
        lifeBarScript.attachedLife = entity.life;
    }


    public void Update () {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(point.position);

        lifeBar.transform.position = screenPosition;
    }
}
