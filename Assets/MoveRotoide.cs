using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotoide : MonoBehaviour
{
    public KeyCode key = KeyCode.U ;
      
    // Start is called before the first frame update
    void Start()
    { 


        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(key)) {
            transform.Rotate(Vector3.up,45);
        }
    }
}
