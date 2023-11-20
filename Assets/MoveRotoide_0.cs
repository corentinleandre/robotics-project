using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotoide_0 : MonoBehaviour
{
      
    // Start is called before the first frame update
    void Start()
    { 


        transform.Rotate(Vector3.up,45);
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.T)) {
            transform.Rotate(Vector3.up,45);
        }
    }
}
