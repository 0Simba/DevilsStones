using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    public Transform target;
    public float     minZoom;
    public float     maxZoom;
    public float     zoomSensibility;
    public Vector3   offset;

    private float currentZoom;

    void Start () {
        offset.Normalize();
        currentZoom = maxZoom;
    }


    void Update () {
        CheckScroll();
        Replace();
    }


    void CheckScroll () {
        float frameSpeed = Input.GetAxis("Mouse ScrollWheel") * zoomSensibility * Time.deltaTime;
        currentZoom = Mathf.Clamp(currentZoom - frameSpeed, minZoom, maxZoom);
    }


    void Replace () {
        transform.position = target.position + offset * currentZoom;
        transform.LookAt(target);
    }

}