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
        // Prend en compte la translation le long de l'axe Z
        Vector3 point = transform.localPosition + translation;
        transform.Translate(translation);

        foreach (var partchild in _children)
        {
            partchild.transform.Translate(translation);
        }

        // Appelle la méthode pour ajuster les autres rotoides
        AdjustRotoidesForTranslation(translation);
    }
    private void AdjustRotoidesForTranslation(Vector3 translation)
    {
        foreach (var partchild in _children)
        {
            // Ajuste la rotation pour maintenir la translation rectiligne
            Vector3 zAxis = partchild.transform.TransformDirection(Vector3.forward);
            partchild.transform.RotateAround(partchild.transform.position, zAxis, translation.z);
        }
    }

    public void TranslatePrismAlongZ(float distance)
    {
        // Créez un vecteur de translation le long de l'axe Z
        Vector3 translation = new Vector3(0f, 0f, distance);

        // Appliquez la translation à la partie actuelle (prisme)
        Translate(translation);
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