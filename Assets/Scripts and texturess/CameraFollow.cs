using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target; // the transform of the object to follow
	public float smoothTime = 0.3f; // the smoothing time for the camera movement

	private Vector3 velocity = Vector3.zero;

	void LateUpdate ()
	{
		// move the camera towards the target position
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
	}
}
