using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public Transform target = null;
    public float     minZoom;
    public float     maxZoom;
    public float     zoomSensibility;
    public Vector3   offset;
    public float     moveMaxSpeed   = 10f;
    public float     lookAtMaxSpeed = 10f;

    private float   currentZoom;
    private Vector3 lastPosition;
    private Vector3 hopePosition;
    private Vector3 lastLookAt;
    private Vector3 hopeLookAt;


    void Awake () {
        EventBus.playerAdded += SetTargetIsPlayer;
    }


    void Start () {
        offset.Normalize();
        currentZoom = maxZoom;
    }


    void OnDestroy () {
        EventBus.playerAdded -= SetTargetIsPlayer;
    }


    void SetTargetIsPlayer (Entity player) {
        if (target != null) {
            return;
        }

        target = player.transform;

        SetHopePosition();
        lastPosition = hopePosition;
    }


    void Update () {
        if (target == null) {
            return;
        }

        CheckScroll();
        SetHopePosition();
        Replace();
    }


    void CheckScroll () {
        float frameSpeed = Input.GetAxis("Mouse ScrollWheel") * zoomSensibility * Time.deltaTime;
        currentZoom = Mathf.Clamp(currentZoom - frameSpeed, minZoom, maxZoom);
    }


    void SetHopePosition () {
        hopePosition = target.position + offset * currentZoom;
    }


    void Replace () {
        transform.position = Vector3.MoveTowards(lastPosition, hopePosition, moveMaxSpeed * Time.deltaTime);

        hopeLookAt = Vector3.MoveTowards(lastLookAt, target.position, lookAtMaxSpeed * Time.deltaTime);
        transform.LookAt(hopeLookAt);

        lastPosition = transform.position;
        lastLookAt   = hopeLookAt;
    }

}