using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteChildren : MonoBehaviour
{
    public GameObject parent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeleteParentsChildren()
    {
        while (parent.transform.childCount > 0)
        {
            GameObject.Destroy(parent.transform.GetChild(0));
        }
    }
}
