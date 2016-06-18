using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

    [HideInInspector] public float current;

    public  bool   isInvincible;
    public  float  max = 100;

    private Entity entity;



    void Start () {
        entity = GetComponent<Entity>();

        entity.OnHit += Lose;
        current = max;
    }


    public void Lose (float damage) {
        if (isInvincible) {
            return;
        }

        current -= damage;

        if (current <= 0) {
            entity.Kill();
        }
    }


}