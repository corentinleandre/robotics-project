using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDriver : MonoBehaviour
{
    private RobotPart _drivedRobotPart;
    public float angleSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _drivedRobotPart = GetComponent<RobotPart>();
    }

    // Update is called once per frame
    void Update()
    {
        _drivedRobotPart.Rotate(angleSpeed);
    }
}
