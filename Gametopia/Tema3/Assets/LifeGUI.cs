using UnityEngine;
using System.Collections;

namespace PlayerMobile {

	public class LifeGUI : MonoBehaviour {

		public BasePlayerController player;

		private Vector3 GUIScale;
		private float healthBarLength;
		private float holderSize;
	    private Texture2D background;
        private Texture2D foreground;

		void Start() {
			float Ratio = (float)Screen.width/1920;
			GUIScale = new Vector3(Ratio,Ratio,1);

			healthBarLength = Screen.width /2;
			holderSize = healthBarLength + 10;

			_CreatePixel(ref background,Color.red);
			_CreatePixel(ref foreground,Color.green);
		}

		void OnGUI() {
			GUI.matrix = Matrix4x4.TRS(new Vector3(GUIScale.x,GUIScale.y, 0), Quaternion.identity,GUIScale);
			GUI.Box(new Rect(0, 0, holderSize, 36), "");
		 	GUI.BeginGroup(new Rect(0,0, healthBarLength,30));
		    	GUI.DrawTexture(new Rect(10, 5, healthBarLength, 30), background, ScaleMode.StretchToFill);
		   	    GUI.DrawTexture(new Rect(10, 5, healthBarLength*player.Life/player.MaxLife, 30), foreground, ScaleMode.StretchToFill);
		    GUI.EndGroup(); 
		}

		void _CreatePixel(ref Texture2D texture, Color color) {
			texture = new Texture2D(1, 1, TextureFormat.RGB24, false);
 			texture.SetPixel(0, 0, color);
 			texture.Apply();
		}
	}
}
