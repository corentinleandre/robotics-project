using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotoide_2 : MonoBehaviour
{
        public float moveSpeed = 10.0f;
     public float stored_moveSpeed = 0.0f;



    // Start is called before the first frame update
    void Start()
    { 


        transform.Rotate(Vector3.up,45);
        
    } 

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.U)) {
transform.Rotate(Vector3.up,45);
}
if ( Input.GetKeyDown(KeyCode.Z)) {
transform.Rotate(Vector3.back,45);
}

if ( Input.GetKeyDown(KeyCode.X)) {
transform.Rotate(Vector3.left,45);
}
    }
}
