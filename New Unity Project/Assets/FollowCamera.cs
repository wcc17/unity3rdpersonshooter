using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
	public GameObject target;
	public float rotateSpeed = 5;
	public static Vector3 offset;

	public static FollowCamera Instance;

	void Start()
	{
		Instance = this;

		target = GameObject.FindGameObjectWithTag("Player");
		offset = target.transform.position - transform.position;
	}

	public void calculateOffset()
	{
		target = GameObject.FindGameObjectWithTag(levelControls.currentPlayerTag);
		offset = target.transform.position - transform.position;
	}

	void LateUpdate()
	{
		if (!levelControls.paused) 
		{
			float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
			target.transform.Rotate (0, horizontal, 0);

			float desiredAngle = target.transform.eulerAngles.y;
			Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
			transform.position = target.transform.position - (rotation * offset);

			transform.LookAt (target.transform);
		}
	}
}
