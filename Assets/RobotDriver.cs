using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotDriver : MonoBehaviour
{
    private RobotPart _drivedRobotPart;
    public float angleSpeed;
    private float _angle;
    private float _target;
    
    // Start is called before the first frame update
    void Start()
    {
        _drivedRobotPart = GetComponent<RobotPart>();
        _angle = 0;
        _target = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target > _angle)
        {
            float currentRotation = Mathf.Min(angleSpeed, _target - _angle);
            _drivedRobotPart.Rotate(currentRotation);
            _angle += currentRotation;
        }

        if (_target < _angle)
        {
            float currentRotation = Mathf.Max(-angleSpeed, _target-_angle);
            _drivedRobotPart.Rotate(currentRotation);
            _angle += currentRotation;
        } 

    }

    public void SetTarget(float newTarget)
    {
        _target = newTarget;
    }

    public RobotPart GetDrivedRobotPart()
    {
        return _drivedRobotPart;
    }
}
