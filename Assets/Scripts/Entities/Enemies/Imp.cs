using UnityEngine;
using System.Collections;

public class Imp : Entity {

    public Transform  spawnBulletPoint;

    private Entity    nearestOpponent = null;
    private float     attackElapsedTime;
    private ImpConfig config;



    new protected void Start () {
        base.Start();

        config = GeneralConfig.instance.impConfig;
    }


    void Update () {
        attackElapsedTime += Time.deltaTime;
        Move();
    }


    void Move () {
        if (nearestOpponent == null) {
            return;
        }


        float opponentDistance = (nearestOpponent.transform.position - transform.position).magnitude;

        if (opponentDistance < config.runAwayDistance) {
            RunAway();
        }
        else if (opponentDistance > config.approachDistance) {
            Approach();
        }
        else {
            Attack();
        }
    }

    public void RunAway () {
        Vector3 direction   = (nearestOpponent.transform.position - transform.position).normalized;
        Vector3 targetPoint = transform.position + direction * -1;
        GoTo(targetPoint);
    }


    public void Approach () {
        Vector3 direction = (nearestOpponent.transform.position - transform.position).normalized;
        Vector3 targetPoint = transform.position + direction;
        GoTo(targetPoint);
    }


    public void Attack () {
        transform.LookAt(nearestOpponent.transform.position);

        if (attackElapsedTime > config.attackFrequency) {
            attackElapsedTime = 0;
            Shoot(config.shoot, spawnBulletPoint.position);
        }
    }


    public void GoTo (Vector3 targetPoint) {
        SetDestination(targetPoint);
        transform.LookAt(targetPoint);
    }


    override public void HeavyUpdate () {
        nearestOpponent = EntitiesManager.GetNearestOpponent(this);
    }
}