using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobotArm : MonoBehaviour
{
    [SerializeField] private RobotDriver one;
    [SerializeField] private RobotDriver two;
    [SerializeField] private RobotDriver three;
    [SerializeField] private RobotDriver four;
    
    [SerializeField] private RobotDriverTrans five;

    [SerializeField] private GameObject traceGroup;

    public GameObject penTipPrefab;

    private Vector3 _targetPoint;
    private Boolean _attained = true;
    private Vector3 _nextTarget;

    private Boolean _update = false;
    private float _minDist;
    private float _maxdist;
    private float _actionsphere;
    private float _oneToTwo;
    private float _twoToThree;
    private float _threeToFour;

    private Boolean _isPenDown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _actionsphere = Vector3.Distance(one.transform.position, GetTip());
        _minDist = Vector3.Distance(four.transform.position, GetTip());
        _maxdist = _minDist + 3;
        _oneToTwo = Vector3.Distance(one.transform.position, two.transform.position);
        _twoToThree = Vector3.Distance(two.transform.position, three.transform.position);
        _threeToFour = Vector3.Distance(three.transform.position, four.transform.position);
        Debug.Log(_actionsphere);
        Debug.Log(_minDist);
        Debug.Log(_maxdist);

        _isPenDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_update)
        {
            _update = true;
            SetNextTarget(GameObject.Find("Example").transform.position);
            //Debug.Log(GameObject.Find("Example").transform.position);
            //Debug.Log(IsInFourthRange());
        }

        if (!_attained)
        {
            one.SetTarget(GetBaseTargetAngle());
            if (IsInFourthRange())
            {
                four.SetTarget(GetFourthTargetAngle());
                five.SetTarget(GetFifthDistance());
            }

            if (Vector3.Distance(_targetPoint, GetTip()) < 0.01)
            {
                _attained = true;
                if (_isPenDown)
                {
                    GameObject point = Instantiate(penTipPrefab, GetTip(), Quaternion.identity);
                    point.transform.SetParent(traceGroup.transform);
                }
                SetNextTarget(_nextTarget);
            }
        }
         
    }

    public void SetNextTarget(Vector3 newTarget)
    {
        Debug.Log("SetNextTarget Called");
        if (_nextTarget == _targetPoint && _targetPoint == newTarget)
        {
            return;
        }
        if (_attained && _nextTarget == _targetPoint)
        {
            _targetPoint = newTarget;
            _nextTarget = newTarget;
            //Debug.Log(_targetPoint);
            _attained = false;
        }
        else if(_attained && _nextTarget != _targetPoint)
        {
            _targetPoint = _nextTarget;
            _attained = false;
            _nextTarget = newTarget;
        }
        else
        {
            _nextTarget = newTarget;
        }
    }

    public Boolean IsNextTargetFree()
    {
        return _targetPoint == _nextTarget;
    }

    public Boolean IsPrismAligned()
    {
        return (_targetPoint - four.transform.position).normalized.Equals(five.transform.forward);
    }

    public Boolean IsArmAligned()
    {
        if (_targetPoint.x == _targetPoint.z && _targetPoint.z == 0)
        {
            return true;
        }
        return false;
    }

    public float GetArmAngle()
    {

        return 0f;
    }

    public Boolean IsInThirdRange()
    {
        if (Vector3.Distance(one.transform.position, _targetPoint) > _actionsphere)
        {
            return false;
        }

        if (Vector3.Distance(three.transform.position, _targetPoint) < _minDist+_threeToFour ||
            Vector3.Distance(three.transform.position, _targetPoint) > _maxdist+_threeToFour)
        {
            return false;
        }

        return true;
    }

    public float GetThirdTargetAngle()
    {
        Vector3 diff = _targetPoint - three.transform.position;
        //On le met dans le repère local
        Vector3 diffInLocal = three.transform.InverseTransformDirection(diff);
        //On part du principe que Z = 0, que qui sera vrai quand la première rotoide aura fini sa trajectoire
        Vector3 diffInLocalProjected = new Vector3(diffInLocal.x, diffInLocal.y, 0f);
        //on normalise pour aller chercher l'angle
        Vector3 normalizedDiffInLocalProjected = diffInLocalProjected.normalized;
        
        //on trouve l'angle
        float alpha1 = Mathf.Acos(normalizedDiffInLocalProjected.x) * Mathf.Rad2Deg;
        float alpha2 = Mathf.Asin(normalizedDiffInLocalProjected.y) * Mathf.Rad2Deg;

        float target;
        //on regarde si on s'appuie sur le cos ou le sin en fonction de la situation
        //on ajoute l'angle courant car on travaille dans le repère local
        if (normalizedDiffInLocalProjected.y > 0)
        {
            target = alpha1 + three.GetAngle();
        }else if(normalizedDiffInLocalProjected.x > 0)
        {   
            target = alpha2 + three.GetAngle();
        }else
        {
            target = three.GetAngle() - alpha1;
        }

        return target;
        //Debug.Log(diffInLocal);
        //return 0f;
    }
    
    public Boolean IsInFourthRange()
    {
        if (Vector3.Distance(one.transform.position, _targetPoint) > _actionsphere)
        {
            return false;
        }

        if (Vector3.Distance(four.transform.position, _targetPoint) < _minDist ||
            Vector3.Distance(four.transform.position, _targetPoint) > _maxdist)
        {
            return false;
        }

        return true;
    }
    
    

    public float GetFourthTargetAngle()
    {
        Vector3 diff = _targetPoint - four.transform.position;
        //On le met dans le repère local
        Vector3 diffInLocal = four.transform.InverseTransformDirection(diff);
        //On part du principe que Z = 0, que qui sera vrai quand la première rotoide aura fini sa trajectoire
        Vector3 diffInLocalProjected = new Vector3(diffInLocal.x, diffInLocal.y, 0f);
        //on normalise pour aller chercher l'angle
        Vector3 normalizedDiffInLocalProjected = diffInLocalProjected.normalized;
        
        //on trouve l'angle
        float alpha1 = Mathf.Acos(normalizedDiffInLocalProjected.x) * Mathf.Rad2Deg;
        float alpha2 = Mathf.Asin(normalizedDiffInLocalProjected.y) * Mathf.Rad2Deg;

        float target;
        //on regarde si on s'appuie sur le cos ou le sin en fonction de la situation
        //on ajoute l'angle courant car on travaille dans le repère local
        if (normalizedDiffInLocalProjected.y > 0)
        {
            target = alpha1 + four.GetAngle();
        }else if(normalizedDiffInLocalProjected.x > 0)
        {   
            target = alpha2 + four.GetAngle();
        }else
        {
            target = four.GetAngle() - alpha1;
        }

        return target;
        //Debug.Log(diffInLocal);
        //return 0f;
    }

    public float GetFifthDistance()
    {
        if (!IsInFourthRange())
        {
            return 0f;
        }

        return Vector3.Distance(four.transform.position, _targetPoint) - _minDist;
    }

    public float GetBaseTargetAngle()
    {
        Vector3 projectedTarget = new Vector3(_targetPoint.x, 0f, _targetPoint.z);
        Vector3 normalizedProjectedTarget = projectedTarget.normalized;
        //Debug.Log(normalizedProjectedTarget);

        float alpha1 = Mathf.Acos(normalizedProjectedTarget.x) * Mathf.Rad2Deg;
        float alpha2 = Mathf.Asin(normalizedProjectedTarget.z) * Mathf.Rad2Deg;
        //Debug.Log(alpha1);
        //Debug.Log(alpha2);
        float target;
        if (normalizedProjectedTarget.z > 0)
        {
            //Debug.Log("target : " + alpha1);
            target = alpha1;
        }else if(normalizedProjectedTarget.x > 0)
        {   
            //Debug.Log("target : " + alpha2);
            target = alpha2;
        }else
        {
            //Debug.Log("target : " + (-alpha1));
            target = -alpha1;
        }
        //Z est dans le mauvais sens
        return -target;
    }

    private Vector3 GetTip()
    {
        Vector3 posOut;
        Quaternion rotOut;
        five.transform.GetPositionAndRotation(out posOut,out rotOut);
        return posOut + five.transform.localScale.z * five.transform.forward;
    }

    public Vector3 GetCurrentTarget()
    {
        return _targetPoint;
    }

    public Vector3 GetNextTarget()
    {
        return _nextTarget;
    }

    public void SetPenDown(Boolean penDown = true)
    {
        _isPenDown = penDown;
    }
    
    public void SetPenUp(Boolean penUp = true)
    {
        _isPenDown = !penUp;
    }
}
