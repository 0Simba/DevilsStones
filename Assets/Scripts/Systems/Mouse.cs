using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/
    
    static public Vector3 floorPosition = Vector3.zero;
    static public bool    isOverFloor   = false;


    /*=====================================
    =            Instance Part            =
    =====================================*/

    public LayerMask layerMask;


    void Update() {
        SetFlorPosition();
    }


    void SetFlorPosition () {
        Ray        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            isOverFloor   = true;
            floorPosition = hit.point;
        }
        else {
            isOverFloor = false;
        }
    }

}