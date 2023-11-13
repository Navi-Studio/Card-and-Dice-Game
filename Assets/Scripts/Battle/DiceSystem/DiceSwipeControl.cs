using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Battle.DiceSystem
{
	public class DiceSwipeControl : MonoSingleton<DiceSwipeControl>
	{
		// Static Instance of the Dice
		public static DiceSwipeControl Instance;

		#region Public Variables

		// Orignal Dice
		public GameObject orignalDice;

		//dice resultant number..
		public int diceCount;

		//dice play view camera...
		public Camera dicePlayCam;

		//Can Throw Dice
		public bool isDiceThrowable = true;
		public Text gui;
		public Transform diceCarrom;
		public static bool isInteractable = false;
		#endregion

		#region Private Varibles

		public GameObject diceClone;
		private Vector3 initPos;
		private float initXpose;

		private float timeRate;

		// To Save Camera Postion
		private Vector3 currentCampPos;
		Vector3 objectPos;
		internal float diceThrowInit;
		
		public static event Action<int> onDiceStop;

		#endregion

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			generateDice();
			onDiceStop = null;
		}

		void Update()
		{
			
			GetComponent<Button>().interactable = isInteractable;
			if (isDiceThrowable)
			{
				if (Input.GetMouseButtonDown(0))
				{
					initPos = Input.mousePosition;
					initXpose = dicePlayCam.ScreenToViewportPoint(Input.mousePosition).x;
				}

				Vector3 currentPos = Input.mousePosition;
				currentPos.z = 25f;
				Vector3 newPos = dicePlayCam.ScreenToWorldPoint(new Vector3(currentPos.x, currentPos.y,
					Mathf.Clamp(currentPos.y / 10, 5, 70)));
				newPos.y = Mathf.Clamp(newPos.y, -114.5f, 100);
				newPos = dicePlayCam.ScreenToWorldPoint(currentPos);
				if (Input.GetMouseButtonUp(0))
				{
					initPos = dicePlayCam.ScreenToWorldPoint(initPos);

					enableTheDice();
					addForce(newPos);
					isDiceThrowable = false;

					StartCoroutine(getDiceCount());
				}
			}
		}

		public void buttonEvent()
		{
			DiceSwipeControl.isInteractable = false;
			Vector3 randomVector = new Vector3(
				Random.Range(-1f, 1f),
				0,
				Random.Range(-1f, 1f)
			);
			addForce(randomVector);
			isDiceThrowable = false;
			StartCoroutine(getDiceCount());
		}

		void addForce(Vector3 lastPos)
		{
			float randomForceMagnitude = 0f;
			do
			{
				randomForceMagnitude = Random.Range(-5000, 5000);
			} while (Mathf.Abs(randomForceMagnitude) < 3000);
			float randomTorqueMagnitude = 0f;
			do
			{
				randomTorqueMagnitude = Random.Range(-5000, 5000);
			} while (Mathf.Abs(randomTorqueMagnitude) < 3000);
			

			Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			randomDirection.x = Mathf.Clamp(randomDirection.x, 0.5f, Mathf.Infinity);
			randomDirection.y = Mathf.Clamp(randomDirection.y, 0.5f, Mathf.Infinity);
			randomDirection.z = Mathf.Clamp(randomDirection.z, 0.5f, Mathf.Infinity);
			randomDirection.Normalize();
			
			// diceClone.GetComponent<Rigidbody>().AddTorque(lastPos * 1000, ForceMode.Impulse);

			
			// Vector3 randomDirection = Random.insideUnitSphere.normalized;
			// float randomForce = Random.Range(-3000f, 3000f);
			// diceClone.GetComponent<Rigidbody>().AddForce(randomDirection * randomForce);
			diceClone.GetComponent<Rigidbody>().AddForce(randomDirection * randomForceMagnitude);
			diceClone.GetComponent<Rigidbody>().AddTorque(randomDirection * randomTorqueMagnitude, ForceMode.Impulse);
		}

		void enableTheDice()
		{
			diceClone.transform.rotation =
				Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
			diceThrowInit = 0;
		}

		void generateDice()
		{
			// diceClone = Instantiate (orignalDice, dicePlayCam.transform.position, Quaternion.Euler (Random.Range (0, 180), Random.Range (0, 180), Random.Range (0, 180))) as GameObject;	
		}

		#region Coroutines

		IEnumerator getDiceCount()
		{
			//Time.timeScale = 1.3f;	
			currentCampPos = dicePlayCam.transform.position;
			//wait fore dice to stop...
			yield return new WaitForSeconds(1.0f);
			while (diceClone.GetComponent<Rigidbody>().velocity.magnitude > 0.05f)
			{
				yield return 0;
			}

			Time.timeScale = 0.2f;
			timeRate = 0.001f;
			float startTime = Time.time;
			Vector3 risePos = dicePlayCam.transform.position;
			Vector3 setPos = new Vector3(diceCarrom.position.x, diceClone.transform.position.y + 25f,
				diceCarrom.position.z);
			float speed = 0.18f;
			// float fracComplete = 0;
			//
			// // while (Vector3.Distance(dicePlayCam.transform.position,setPos)>0.5f) 
			// //             {
			// 		Vector3 center = (risePos + setPos) * 0.5f;
			// 		center -= new Vector3 (0, 2, -1);
			// 		Vector3 riseRelCenter = risePos - center;
			// 		Vector3 setRelCenter = setPos - center;

			// if (fracComplete > 0.85f && fracComplete < 1f) {
			// 		speed += Time.deltaTime * 0.3f;
			// 		Time.timeScale -= Time.deltaTime * 4f;
			// } 
			// dicePlayCam.transform.position = Vector3.Slerp (riseRelCenter, setRelCenter, fracComplete);
			// dicePlayCam.transform.position += center;
			// dicePlayCam.transform.LookAt (diceCarrom);
			// fracComplete = (Time.time - startTime) / speed;
			// yield return 0;
			// }

			Time.timeScale = 1.0f;
			Dice.Instance.GetDiceCount();
			// gui.text = Dice.Instance.GetDiceCount().ToString();
			onDiceStop?.Invoke((int)Dice.Instance.GetDiceCount());
			yield return new WaitForSeconds(5f);

			Dice.Instance.diceCount = 0;
			Dice.Instance.GetDiceCount();
			diceCount = Dice.Instance.GetDiceCount();
			// gui.text = diceCount.ToString();
			diceClone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			// Application.LoadLevel(0);
		}

		#endregion
	}
}