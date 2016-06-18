using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    /*===================================
    =            Static Part            =
    ===================================*/
    
    static public Vector3 floorPosition = Vector3.zero;
    static public Entity  entityOver    = null;
    static public bool    isOverFloor   = false;
    static public bool    isOverEntity  = false;



    /*=====================================
    =            Instance Part            =
    =====================================*/

    public LayerMask floorMask;
    public LayerMask entityMask;


    void Update() {
        SetFloorPosition();
        SetEntityOver();
    }


    void SetFloorPosition () {
        Ray        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask)) {
            isOverFloor   = true;
            floorPosition = hit.point;
        }
        else {
            isOverFloor = false;
        }
    }   


    void SetEntityOver () {
        Ray        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, entityMask)) {
            isOverEntity = true;
            entityOver   = hit.transform.gameObject.GetComponent<Entity>();
        }
        else {
            entityOver   = null;
            isOverEntity = false;
        }
    }

}