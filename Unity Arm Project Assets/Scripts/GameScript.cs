using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] GameObject head;
    [SerializeField] GameObject body;
    [SerializeField] GameObject arm;
    [SerializeField] Material highlight;
    
    bool headColor;
    bool bodyColor;

    [SerializeField] float armSpeed;

    bool isTouched = false;
    bool isHit = false;

    [SerializeField] Draggable draggable;

    MeshRenderer MRH;
    MeshRenderer MRB;
    [SerializeField] [Range(0F, 1F)] float lerpTime;

    bool first;
    bool second;
    bool success;

    void Start() {
        Application.targetFrameRate = 60;
        MRH = head.GetComponent<MeshRenderer>();
        MRB = body.GetComponent<MeshRenderer>();

        draggable.dragLock = true;
        success = false;
    }

    void Update()
    {
        if((first && second) && !isTouched) {
            success = true;
        }

        if(isTouched && !success) {
            ArmDown();
        }

        if(draggable.dragLock && success) {
            draggable.dragLock = false;
        }

        if(headColor) {
            ColorH();
        }
        if(bodyColor) {
            ColorB();
        }

        if(Input.GetMouseButtonDown(0) && !success && !isTouched) {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Debug.Log(ray.direction);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider != null) {
                    if(!(first && second)) {
                        if(hit.collider.tag == "Head") {
                            Invoke("TrueH", 0.45F);
                        }
                        else if(hit.collider.tag == "Body") {
                            Invoke("TrueB", 0.45F);
                        }
                    }
                }
            }
             var pos = ray.direction;
             pos.y = 0;

             arm.transform.LookAt(pos);

             var loc = ray.direction.z;
             loc += 0.4F;
             loc *= 112.5F;
             loc -= 135;

            arm.transform.rotation = Quaternion.Euler(0F, loc, 0F);
            isTouched = true;
        }
    }

    void ArmDown() {

        if(!isHit) {
            arm.transform.Rotate(new Vector3(armSpeed, 0, 0) * Time.deltaTime);

            if(arm.transform.eulerAngles.x >= 70F) {
            isHit = true;
            }
        } else {
            arm.transform.Rotate(new Vector3(-armSpeed, 0, 0) * Time.deltaTime);

            if(arm.transform.eulerAngles.x == 0F || (arm.transform.eulerAngles.x <= 360 && arm.transform.eulerAngles.x >= 120)) {
                isHit = false;
                isTouched = false;
                arm.transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);
            }
        }
        
        
    }

    void ColorH() {
        // head.GetComponent<Renderer>().material = highlight;
        MRH.material.color = Color.Lerp(MRH.material.color, color, lerpTime);
        first = true;
    }
    void ColorB() {
        // body.GetComponent<Renderer>().material = highlight;
        MRB.material.color = Color.Lerp(MRB.material.color, color, lerpTime);
        second = true;
    }

    void TrueH() {
        headColor = true;
    }
    void TrueB() {
        bodyColor = true;
    }
}
