using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public float movementSpeed = 10;
	Animator anim;
	public Object currentPlayer;

	void Start ()
	{
		anim = GetComponent <Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if(this.tag == levelControls.currentPlayerTag)
		{
			float horizontal = Input.GetAxis ("Horizontal") * movementSpeed * Time.deltaTime;
			transform.Translate (horizontal, 0, 0);

			float vertical = Input.GetAxis ("Vertical") * movementSpeed * Time.deltaTime;
			transform.Translate (0, 0, vertical);

			if (Input.GetKeyDown ("space")) 
			{
				if(transform.position.y <= 0)
				{
					//anim.SetBool ("IsJumping", true);
					transform.Translate (Vector3.up * 260 * Time.deltaTime, Space.World);
				}
			}
			else
			{
				if(transform.position.y <= 0)
				{
					anim.SetBool ("IsJumping", false);
				}
			}

			if( (horizontal != 0f) || (vertical != 0f) )
			{
				anim.SetBool ("IsWalking", true);
			}
			else
			{
				anim.SetBool ("IsWalking", false);
			}

			if(Input.GetMouseButtonDown(0))
			{
				anim.SetLayerWeight(1, 1);
				anim.SetTrigger("Shoot");
			}
			if(Input.GetMouseButtonDown (1))
			{
				anim.SetTrigger ("Hit");
			}
		}
	}
}
