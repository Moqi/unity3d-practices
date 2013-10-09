using UnityEngine;
using System.Collections;

namespace MyExample {
	
	public enum Actions {
			 NONE = 0
	       , FORWARD = 1
		   , BACKWARD = 2
	}
	
	public class BaseMovement : MonoBehaviour {
		
		#region Constants
		
		const double constTime = 5.0;
		const double constForwardLimit = -50.0;
		const double constBackwardLimit = -26.0;
		
		#endregion
		
		#region Public Props
		
		public Actions Action;
		public float Speed;
		public bool Stuck {
			get { return p_Stuck; }
		}
		
		#endregion
		
		#region Private Props
	
		private bool p_Stuck;
		private float p_StartTime;
		private Transform p_Transform;
		
		#endregion
	
		void Start () {
		   p_Transform = transform;
		   NewRandomDecision();
		   p_Stuck = false;
		}
		
		void Update () {
		  if (!p_Stuck && Time.timeSinceLevelLoad < p_StartTime + constTime) {
			 switch(Action) {
				case Actions.FORWARD:
					 if ( p_Transform.position.y > constForwardLimit) {
						p_Transform.Translate(p_Transform.forward * Speed * Time.deltaTime);
					 } else {
						p_Stuck = true;
					 }
					break;
				case Actions.BACKWARD:
					if ( p_Transform.position.y < constBackwardLimit) {
						p_Transform.Translate(p_Transform.forward * Speed * -1 * Time.deltaTime);
					} else {
						p_Stuck = true;
					}
					break;
				default:
					//TODO: ERROR!! Wrong Code
					break;
			 }
		  } else {
			NewRandomDecision();	
		  }			
		}
		
		private void NewRandomDecision()
		{
		  p_Stuck = false;
		  p_StartTime = Time.timeSinceLevelLoad;
		  Action = (Actions)Random.Range(1,3);
		}
	}
}