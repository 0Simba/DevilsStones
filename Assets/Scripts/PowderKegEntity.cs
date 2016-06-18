using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Entity))]
public class PowderKegEntity : MonoBehaviour {

    public  GameObject explosionPrefab;
    public  float      lifeLostPerSecond = 1.5f;

    private Entity     entity;



    void Start () {
        entity = GetComponent<Entity>();
        entity.OnDie += Explode;
    }


    void Update () {
        entity.Hit(lifeLostPerSecond * Time.deltaTime);
    }


    void Explode () {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}