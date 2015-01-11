using UnityEngine;
using System.Collections;

public class levelControls : MonoBehaviour 
{
	public static bool paused;
	public static string currentPlayerTag;
	public static GameObject currentGameObject;
	public static GameObject regularPlayerObject;
	public static GameObject heavyPlayerObject;
	public static GameObject sniperPlayerObject;
	public static levelControls Instance;

	// Use this for initialization
	void Start () 
	{
		paused = false;
		currentPlayerTag = "Player";
		regularPlayerObject = GameObject.FindGameObjectWithTag("Player");
		heavyPlayerObject = GameObject.FindGameObjectWithTag ("heavy_player");
		sniperPlayerObject = GameObject.FindGameObjectWithTag ("sniper_player");

		currentGameObject = regularPlayerObject;
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("escape")) 
		{
			if(paused)
			{
				paused = false;
			}
			else
			{
				paused = true;
			}
		}
		
		if (paused) 
		{
			Time.timeScale = 0;
		} 
		else 
		{
			Time.timeScale = 1;
		}
	}

	void OnGUI()
	{
		if(paused)
		{
			GUILayout.Label ("Game is paused!");
			float positionX, positionY, positionZ;
			float rotateX, rotateY, rotateZ;
			Vector3 newPos;
			Vector3 newRot;

			if(GUILayout.Button ("Click me to unpause"))
			{
				paused = false;
			}

			if(GUILayout.Button ("Play as Regular"))
			{
				//get positions of the current object
				positionX = currentGameObject.transform.position.x;
				positionY = currentGameObject.transform.position.y;
				positionZ = currentGameObject.transform.position.z;
				rotateX = currentGameObject.transform.eulerAngles.x;
				rotateY = currentGameObject.transform.eulerAngles.y;
				rotateZ = currentGameObject.transform.eulerAngles.z;

				//change currentPlayer tag to current Player
				currentPlayerTag = "Player";

				//get position of current object
				newPos = new Vector3(positionX, positionY, positionZ);
				newRot = new Vector3(rotateX, rotateY, rotateZ);

				//disable current object, calculate new camera offset
				currentGameObject.SetActive(false);

				//change currentGameObject to the new current player
				//calculate new camera offset for new player
				currentGameObject = regularPlayerObject;
				currentGameObject.SetActive(true);

				//make sure we can see the new player and set its position
				currentGameObject.transform.position = newPos;
				currentGameObject.transform.eulerAngles = newRot;
				FollowCamera.Instance.calculateOffset();
			}

			if(GUILayout.Button ("Play as Heavy"))
			{
				//get positions of the current object
				positionX = currentGameObject.transform.position.x;
				positionY = currentGameObject.transform.position.y;
				positionZ = currentGameObject.transform.position.z;
				rotateX = currentGameObject.transform.eulerAngles.x;
				rotateY = currentGameObject.transform.eulerAngles.y;
				rotateZ = currentGameObject.transform.eulerAngles.z;
				
				//change currentPlayer tag to current Player
				currentPlayerTag = "heavy_player";
				
				//get position of current object
				newPos = new Vector3(positionX, positionY, positionZ);
				newRot = new Vector3(rotateX, rotateY, rotateZ);
				
				//disable current object, calculate new camera offset
				currentGameObject.SetActive(false);
				
				//change currentGameObject to the new current player
				//calculate new camera offset for new player
				currentGameObject = heavyPlayerObject;
				currentGameObject.SetActive(true);
				
				//make sure we can see the new player and set its position
				currentGameObject.transform.position = newPos;
				currentGameObject.transform.eulerAngles = newRot;
				FollowCamera.Instance.calculateOffset();
			}

			if(GUILayout.Button ("Play to Ranged"))
			{
				//get positions of the current object
				positionX = currentGameObject.transform.position.x;
				positionY = currentGameObject.transform.position.y;
				positionZ = currentGameObject.transform.position.z;
				rotateX = currentGameObject.transform.eulerAngles.x;
				rotateY = currentGameObject.transform.eulerAngles.y;
				rotateZ = currentGameObject.transform.eulerAngles.z;
				
				//change currentPlayer tag to current Player
				currentPlayerTag = "sniper_player";
				
				//get position of current object
				newPos = new Vector3(positionX, positionY, positionZ);
				newRot = new Vector3(rotateX, rotateY, rotateZ);
				
				//disable current object, calculate new camera offset
				currentGameObject.SetActive(false);
				
				//change currentGameObject to the new current player
				//calculate new camera offset for new player
				currentGameObject = sniperPlayerObject;
				currentGameObject.SetActive(true);
				
				//make sure we can see the new player and set its position
				currentGameObject.transform.position = newPos;
				currentGameObject.transform.eulerAngles = newRot;
				FollowCamera.Instance.calculateOffset();
			}

			if(GUILayout.Button ("Play as Melee"))
			{
				currentPlayerTag = "melee_player";
			}

			if(GUILayout.Button ("Play as Medic"))
			{
				currentPlayerTag = "medic_palyer";
			}
		}
	}
}
