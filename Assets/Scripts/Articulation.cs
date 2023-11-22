using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Articulation : MonoBehaviour
{
    public GameObject origin;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = origin.transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
