using UnityEngine;
using System.Collections;

namespace PlayerMobile {
	
	public enum Actions {
			 NONE
	       , FORWARD 
		   , BACKWARD 
		   , TURN_LEFT
		   , TURN_RIGHT
		   , STUCK  // TODO: For Future check if the player is blocked!!!
	}
	
	public class BasePlayerController : MonoBehaviour {
		
		#region Constants
		
		const int cMaxLife = 100;
		const int cMinLife = 0;
		
		#endregion

		#region Public Props
		
		public Actions Action;
		public float Speed;
		public int MaxLife {
			get { return cMaxLife; }
		}
		public int Life {
			get { return p_Life; }
		}

		#endregion
		
		#region Private Props

		private Transform p_Transform;
		private int p_Life;

		#endregion
	
		void Start () {
		   p_Life = cMinLife;
		   p_Transform = transform;
		   Action = Actions.NONE;
		}
		
		void Update () {
			//CHECK FORWARD AND BACKWARD KEYS
			if (GetAnyKey(KeyCode.UpArrow, KeyCode.W)) {
				p_Transform.Translate(p_Transform.forward * Speed * Time.deltaTime);
				Action = Actions.FORWARD;
				p_Life += p_Life < cMaxLife ? 1 : 0; //Check Life Over Max Life
			} else if (GetAnyKey(KeyCode.DownArrow, KeyCode.S)) {
				p_Transform.Translate(p_Transform.forward * Speed * -1 * Time.deltaTime);
				Action = Actions.BACKWARD;
				p_Life -= p_Life == cMinLife ? 0 : 1; // Check Life Under Min Life
			}
			//CHECK ROTATION KEYS
			if (GetAnyKey(KeyCode.RightArrow, KeyCode.D)) {
				p_Transform.Rotate(p_Transform.up * Speed * Time.deltaTime);
				Action = Actions.TURN_RIGHT;
			} else if (GetAnyKey(KeyCode.LeftArrow, KeyCode.A)) {
				p_Transform.Rotate(p_Transform.up * Speed * -1 * Time.deltaTime);
				Action = Actions.TURN_LEFT;
			}
		}

		bool GetAnyKey(params KeyCode[] aKeys) {
		    foreach(var key in aKeys) {
		        if (Input.GetKey(key)) {
		            return true;
		        }
		    }
		    return false;
		}
	}
}