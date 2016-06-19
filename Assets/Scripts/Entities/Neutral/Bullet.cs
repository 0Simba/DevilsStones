using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed    = 10;
    public float lifeTime = 2f;
    public float damage   = 5;



    public void Init (float speed, float lifeTime, float damage) {
        this.speed    = speed;
        this.lifeTime = lifeTime;
        this.damage   = damage;
    }


    void Update () {
        transform.position += transform.forward * speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0) {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter (Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Entity")) {
            return;
        }

        Entity entity = other.gameObject.GetComponent<Entity>();
        entity.Hit(damage);

        Destroy(gameObject);
    }
}