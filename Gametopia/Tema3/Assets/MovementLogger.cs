using UnityEngine;
using System.Collections;

namespace MyExample {
	
	public class MovementLogger : MonoBehaviour {
		
		public BaseMovement myMovement;
		
		void Update () {
			string text = "";
			switch(myMovement.Action) {
				case Actions.FORWARD:
					text = "FORWARD MOVEMENT!";
					break;
				case Actions.BACKWARD:
					text = "BACKWARD MOVEMENT!";
					break;
				default:
					text = "NOT MOVEMENT!";
					break;
			 }
			text += myMovement.Stuck ? " IS BLOCKED!!" : "";
		    Debug.Log(text);
		}
	}
}
