using UnityEngine;
using System.Collections;

public class Imp : Entity {

    public Transform  spawnBulletPoint;

    private Entity    entity;
    private Entity    player;
    private float     attackElapsedTime;
    private ImpConfig config;



    void Start () {
        player = Player.instance.gameObject.GetComponent<Entity>();
        entity = GetComponent<Entity>();
        config = GeneralConfig.instance.impConfig;
    }


    void Update () {
        attackElapsedTime += Time.deltaTime;
        Move();
    }


    void Move () {
        float playerDistance = (player.transform.position - transform.position).magnitude;

        if (playerDistance < config.runAwayDistance) {
            RunAway();
        }
        else if (playerDistance > config.approachDistance) {
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

        if (attackElapsedTime > config.attackFrequency) {
            attackElapsedTime = 0;
            Shoot(config.shoot, spawnBulletPoint.position);
        }
    }


    public void GoTo (Vector3 targetPoint) {
        entity.SetDestination(targetPoint);
        transform.LookAt(targetPoint);
    }

}