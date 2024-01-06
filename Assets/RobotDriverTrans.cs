using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDriverTrans : MonoBehaviour
{
    private RobotPart _drivedRobotPart;
    public float transSpeed;
    private float _dist = 0;
    private float _target;

    // Start is called before the first frame update
    void Start()
    {
        _drivedRobotPart = GetComponent<RobotPart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target > _dist)
        {
            float currentTranslation = Mathf.Min(transSpeed, _target - _dist);
            _drivedRobotPart.TranslatePrismAlongZ(currentTranslation);
            _dist += currentTranslation;
        }

        if (_target < _dist)
        {
            float currentTranslation = Mathf.Max(-transSpeed, _target-_dist);
            _drivedRobotPart.TranslatePrismAlongZ(currentTranslation);
            _dist += currentTranslation;
        } 
    }

    public void SetTarget(float newTarget)
    {
        _target = newTarget;
    }
}
