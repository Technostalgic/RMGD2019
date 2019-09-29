using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public sealed class TooltipTextController : MonoBehaviour {

		// Properties and Fields: -----------------------------------------------------------------

		// this is an non rigid example of a singleton pattern, there will always be a publicly accessible 
		// TooltipTextController object in the scene by referencing TooltipTextController.instance
		private static TooltipTextController _instance;
		public static TooltipTextController instance {
			get {
				if(_instance == null)
					_instance = GameObject.FindObjectOfType<TooltipTextController>();
				return _instance;
			}
		}

		public RectTransform rectTransform => transform as RectTransform;

		private TextMeshProUGUI _tmp;
		public TextMeshProUGUI tmp {
			get {
				if(_tmp == null)
					_tmp = GetComponent<TextMeshProUGUI>();
				return _tmp;
			}
		}

		public string text {
			get {
				return tmp.text;
			}
			set {
				tmp.text = value;
			}
		}

		// Static Methods: ------------------------------------------------------------------------

		/// <summary>
		/// this will show the singleton instance of the TooltipTextController object with the specified tooltip
		/// </summary>
		/// <param name="tooltip"></param>
		public static void Show(string tooltip) {
			instance.show(tooltip);
		}

		/// <summary>
		/// this will hide the singleton instance of the TooltipTextController object
		/// </summary>
		public static void Hide() {
			instance.hide();
		}

		// Object Methods: ------------------------------------------------------------------------

		private void show(string tooltip) {
			positionToCursor();
			gameObject.SetActive(true);
			tmp.text = tooltip;
		}

		private void hide() {
			gameObject.SetActive(false);
		}

		private void positionToCursor() {

			rectTransform.position = Input.mousePosition + new Vector3(0, -25);

			// if the tooltip goes past the edge of the screen, move it to the left
			float dif = (rectTransform.position.x + rectTransform.rect.width) - Screen.width;
			if(dif >= 0) {
				rectTransform.position += new Vector3(-dif, 0);
			}
		}

		// Unity Callback Methods: ----------------------------------------------------------------

		private void Awake() {
			_instance = this;
			hide();
		}

		private void Update() {
			positionToCursor();
		}
	}
}