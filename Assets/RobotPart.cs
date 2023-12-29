using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
	public RobotPart parent;
	public RobotPart child;
	private List<RobotPart> _children = new List<RobotPart>();

	//Methods
	public void Rotate(float angle)
	{
		Vector3 zAxis = transform.TransformDirection(new Vector3(0, 0, 1));
		Vector3 point = transform.localPosition;
		transform.RotateAround(point, zAxis, angle);

        foreach (var partchild in _children) 
		{
			partchild.transform.RotateAround(point, zAxis, angle);
		}
	}

	public void Translate(Vector3 translation)
{
		Vector3 point = transform.localPosition;
        transform.Translate(translation);

		foreach (var partchild in _children) 
		{
			partchild.transform.Translate(translation);
		}
	}


	// Start is called before the first frame update
	void Start()
	{
		RobotPart currChild = this;
		while (currChild.GetComponent<RobotPart>().child != null)
		{
			_children.Add(currChild.GetComponent<RobotPart>().child);
			currChild = currChild.GetComponent<RobotPart>().child;
		}
	}

	// Update is called once per frame
	void Update()
	{	
		//GetComponent<RobotPart>().RotateAround(transform.localPosition, new Vector3(1, 0, 0), 1);
	}
}