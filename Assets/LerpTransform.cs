using UnityEngine;

public class LerpTransform : MonoBehaviour
{
	public Transform startTransform;
	public Transform endTransform;
	public float lerpSpeed = 1f;

	void Update ()
	{
		this.transform.position = Vector3.Lerp(this.transform.position, endTransform.position, lerpSpeed * Time.deltaTime);
		this.transform.rotation = Quaternion.Lerp(this.transform.rotation, endTransform.rotation, lerpSpeed * Time.deltaTime);
	}
}
