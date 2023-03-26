using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRot : MonoBehaviour
{
	public Transform t;
	void Update ()
	{
		t.eulerAngles = new Vector3(0, 0, 0);
	}

}
