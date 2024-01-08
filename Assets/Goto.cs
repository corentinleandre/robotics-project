using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Goto : MonoBehaviour
{
    // Start is called before the first frame update
    public RobotArm robotArm;
    
    public TMP_InputField x1;
    public TMP_InputField y1;
    public TMP_InputField z1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        robotArm.SetNextTarget(new Vector3(float.Parse(x1.text), float.Parse(y1.text), float.Parse(z1.text)));
    }
}
