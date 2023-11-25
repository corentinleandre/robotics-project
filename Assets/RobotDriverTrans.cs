using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDriverTrans : MonoBehaviour
{
    private RobotPart _drivedRobotPart;
    public Vector3 transSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _drivedRobotPart = GetComponent<RobotPart>();
    }

    // Update is called once per frame
    void Update()
    {
        _drivedRobotPart.Translate(transSpeed);
    }
}
