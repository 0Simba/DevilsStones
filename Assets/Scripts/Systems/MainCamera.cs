using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public Transform target;
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



    void Start () {
        offset.Normalize();
        currentZoom = maxZoom;

        SetHopePosition();
        lastPosition = hopePosition;
    }


    void Update () {
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