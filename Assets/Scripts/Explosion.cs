using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float     duration  = 0.5f;
    public float     damage    = 5;
    public float     range     = 5;
    public LayerMask layerMask;


    void Start () {
        SetDamages();
        StartCoroutine(ExplosionAnimation());
    }


    void SetDamages () {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, layerMask);

        for (int i = hitColliders.Length - 1; i >= 0; --i) {
            Entity entity = hitColliders[i].GetComponent<Entity>();
            entity.Hit(damage);
        }        
    }


    IEnumerator ExplosionAnimation () {
        transform.localScale = new Vector3(0, 0, 0);
        float elapsedTime = 0;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;

            float ratio = Mathf.Min(1, elapsedTime / duration);
            float size  = ratio * range;
            transform.localScale = new Vector3(size, size, size);

            yield return null;
        }

        Destroy(gameObject);
    }
}