using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

    public RectTransform fill;
    public Life          attachedLife;


    void Update () {
        float lifeRatio = attachedLife.current / attachedLife.max;
        fill.anchorMax = new Vector2(lifeRatio, 0.5f);
    }
}