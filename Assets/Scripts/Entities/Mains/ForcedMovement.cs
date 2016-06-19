using UnityEngine;
using System;
using System.Collections;

public class ForcedMovement : MonoBehaviour {

    public delegate void BoolCallback (bool boolean);


    [HideInInspector] public Vector3        startPosition;
    [HideInInspector] public Vector3        endPosition;
    [HideInInspector] public float          duration;
    [HideInInspector] public AnimationCurve curve;

    public  bool         isIt        = false;
    private float        elapsedTime = 0;
    private BoolCallback endCallback;


    public void Set (Vector3 startPosition, Vector3 endPosition, float duration, AnimationCurve curve, BoolCallback endCallback = null) {
        CallEndback(isIt);

        this.endCallback   = endCallback;
        this.startPosition = startPosition;
        this.endPosition   = endPosition;
        this.duration      = duration;
        this.curve         = curve;

        elapsedTime = 0;
        isIt        = true;
    }


    void Update () {
        if (!isIt) {
            return;
        }


        elapsedTime += Time.deltaTime;

        float ratio        = Mathf.Min(1, elapsedTime / duration);
        float curvedRatio  = curve.Evaluate(ratio);

        transform.position = startPosition + ((endPosition - startPosition) * curvedRatio);

        if (ratio == 1) {
            isIt = false;
            CallEndback(isIt);
        }
    }


    void CallEndback (bool interupted) {
        if (endCallback != null) {
            endCallback(interupted);
            endCallback = null;
        }
    }
}