using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ellipse : MonoBehaviour
{
    public RobotArm robotArm;

    public TMP_InputField x1;
    public TMP_InputField y1;
    public TMP_InputField z1;
    
    public TMP_InputField x2;
    public TMP_InputField y2;
    public TMP_InputField z2;
    
    public TMP_InputField x3;
    public TMP_InputField y3;
    public TMP_InputField z3;

    private Boolean _finished;

    private Vector3 center;
    private Vector3 a;
    private Vector3 b;
    private float current;
    
    // Start is called before the first frame update
    void Start()
    {
        _finished = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_finished)
        {
            if (current > 2*Mathf.PI)
            {
                _finished = true;
                return;
            }
            if (robotArm.IsNextTargetFree())
            {
                current += 10 * Mathf.Deg2Rad;
                robotArm.SetNextTarget(center+Mathf.Cos(current) * VectA() + Mathf.Sin(current) * VectB());
            }
        }
    }

    public void OnButtonClick()
    {
        if (!_finished)
        {
            return;
        }
        center = new Vector3(float.Parse(x1.text), float.Parse(y1.text), float.Parse(z1.text));
        a = new Vector3(float.Parse(x2.text), float.Parse(y2.text), float.Parse(z2.text));
        b = new Vector3(float.Parse(x3.text), float.Parse(y3.text), float.Parse(z3.text));
        current = 0;
        
        robotArm.SetNextTarget(center+Mathf.Cos(current) * VectA() + Mathf.Sin(current) * VectB());
        _finished = false;
    }

    private Vector3 VectA()
    {
        return a - center;
    }

    private Vector3 VectB()
    {
        return b - center;
    }
    
    
}
