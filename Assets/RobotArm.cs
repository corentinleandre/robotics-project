using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArm : MonoBehaviour
{
    [SerializeField] private RobotDriver _one;
    [SerializeField] private RobotDriver _two;
    [SerializeField] private RobotDriver _three;
    [SerializeField] private RobotDriver _four;
    
    [SerializeField] private RobotDriverTrans _five;

    private Vector3 _targetPoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTarget(Vector3 newTarget)
    {
        _targetPoint = newTarget;
    }

    /*private Vector3 getTip()
    {
        return _five.transform.getPositionAndRotation();
    }*/
}
