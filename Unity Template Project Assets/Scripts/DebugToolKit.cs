using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugToolKit : MonoBehaviour
{
    BoxCollider2D BC;
    
    void DrawAll() {
        print("HELLOOO");
        BC = GetComponent<BoxCollider2D>();
        Debug.DrawRay(BC.bounds.center, Vector2.down * BC.bounds.extents.y);
    }

    void Update() {
        DrawAll();
    }
   
}
