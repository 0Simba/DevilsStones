using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Entity))]
public class Imp : MonoBehaviour {

    public float      runAwayDistance  = 3;
    public float      approachDistance = 10;
    public float      attackFrequency  = 1f;
    public GameObject bullet;
    public Transform  spawnBulletPoint;

    private Entity entity;
    private Entity player;
    private float  attackElapsedTime;

    void Start () {
        player = Player.instance.gameObject.GetComponent<Entity>();
        entity = GetComponent<Entity>();
    }


    void Update () {
        attackElapsedTime += Time.deltaTime;
        Move();
    }


    void Move () {
        float playerDistance = (player.transform.position - transform.position).magnitude;

        if (playerDistance < runAwayDistance) {
            RunAway();
        }
        else if (playerDistance > approachDistance) {
            Approach();
        }
        else {
            Attack();
        }
    }

    public void RunAway () {
        Vector3 direction   = (player.transform.position - transform.position).normalized;
        Vector3 targetPoint = transform.position + direction * -1;
        GoTo(targetPoint);
    }


    public void Approach () {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Vector3 targetPoint = transform.position + direction;
        GoTo(targetPoint);
    }


    public void Attack () {
        transform.LookAt(player.transform.position);

        if (attackElapsedTime > attackFrequency) {
            attackElapsedTime = 0;
            Shoot();
        }
    }


    public void Shoot () {
        Instantiate(bullet, spawnBulletPoint.position, transform.rotation);
    }



    public void GoTo (Vector3 targetPoint) {
        entity.SetDestination(targetPoint);
        transform.LookAt(targetPoint);
    }

}