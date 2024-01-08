using System;
using TMPro;
using UnityEngine;

public class Line : MonoBehaviour
{
    public RobotArm robotArm;

    public TMP_InputField x1;
    public TMP_InputField y1;
    public TMP_InputField z1;
    
    public TMP_InputField x2;
    public TMP_InputField y2;
    public TMP_InputField z2;

    private Boolean _finished;

    private Vector3 start;
    private Vector3 end;
    private Vector3 current;
    
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
            if (Vector3.Distance(current, end) < 0.2)
            {
                _finished = true;
                robotArm.SetPenUp();
                return;
            }
            if (robotArm.IsNextTargetFree())
            {
                current += Vect().normalized * 0.2f;
                robotArm.SetNextTarget(current);
            }
        }
    }

    public void OnButtonClick()
    {
        if (!_finished)
        {
            return;
        }
        end = new Vector3(float.Parse(x2.text), float.Parse(y2.text), float.Parse(z2.text));
        start = new Vector3(float.Parse(x1.text), float.Parse(y1.text), float.Parse(z1.text));
        current = start;
        robotArm.SetNextTarget(new Vector3(float.Parse(x1.text), float.Parse(y1.text), float.Parse(z1.text)));
        robotArm.SetPenDown();
        _finished = false;
    }

    private Vector3 Vect()
    {
        return end - start;
    }
}
