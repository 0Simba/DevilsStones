using UnityEngine;
using System.Collections;

public class ForcedMovement : MonoBehaviour {

    [HideInInspector] public Vector3        startPosition;
    [HideInInspector] public Vector3        endPosition;
    [HideInInspector] public float          duration;
    [HideInInspector] public AnimationCurve curve;

    public  bool  isIt        = false;
    private float elapsedTime = 0;


    public void ForceMoment(Vector3 startPosition, Vector3 endPosition, float duration, AnimationCurve curve) {
        this.startPosition = startPosition;
        this.endPosition   = endPosition;
        this.duration      = duration;
        this.curve         = curve;

        elapsedTime = 0;
        isIt = true;
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
        }
    }
}