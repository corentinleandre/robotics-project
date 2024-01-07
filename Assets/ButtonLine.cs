using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Runtime.CompilerServices;

public class ButtonLine : MonoBehaviour
{
    [SerializeField] private RobotPart robotPart;
    [SerializeField] private RobotPart robotPartRotoide;
    private int orderLine = 0;
    private float transition = 0.1f;
    private void Start()
    {


    }

    public void OnButtonClick()
    {
        if (orderLine % 2 == 0)
        {
            StartCoroutine(RotateOverTime());
            orderLine++;
        }
        else
        {
            StartCoroutine(AntiRotateOverTime());
            orderLine++;
        }
    }
    private IEnumerator RotateOverTime()
    {
        float elapsedTime = 0f;
        float targetAngle = 45f;
        float totalRotationTime = 1.0f;
        float angularSpeed = targetAngle / totalRotationTime;
        float targetY = robotPart.transform.position.y;

        while (elapsedTime < totalRotationTime)
        {

            float errorMargin = 0.1f;
            float angleToRotate = angularSpeed * Time.deltaTime;

            if ((robotPart.transform.position.y - targetY) < errorMargin)
            {
                robotPart.Translate(new Vector3(0, 0, transition));
                yield return null;
            }
            else
            {
                robotPart.Translate(new Vector3(0, 0, -transition));
                yield return null;

            }
            robotPartRotoide.Rotate(angleToRotate);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


private IEnumerator AntiRotateOverTime()
    {
        float elapsedTime = 0f;
        float targetAngle = -45f;
        float totalRotationTime = 1.0f;
        float angularSpeed = targetAngle / totalRotationTime;
        float targetY = robotPart.transform.position.y;
        while (elapsedTime < totalRotationTime)
        {
   
            float errorMargin = 0.1f;
            float angleToRotate = angularSpeed * Time.deltaTime;

            if ((robotPart.transform.position.y - targetY) < errorMargin)
            {
                robotPart.Translate(new Vector3(0, 0, transition));
                yield return null;
            }
            else
            {
                robotPart.Translate(new Vector3(0, 0, -transition));
                yield return null;

            }
            robotPartRotoide.Rotate(angleToRotate);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

}
