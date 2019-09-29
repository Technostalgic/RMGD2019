using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public class RoomButtonController : MonoBehaviour {

		// Properties and Fields: -----------------------------------------------------------------

		public RectTransform rectTransform => transform as RectTransform;

		public RoomConstructionData constructionData;

		[SerializeField]
		private TextMeshProUGUI _textMesh;
		internal TextMeshProUGUI textMesh {
			get {
				if(_textMesh == null) {
					_textMesh = GetComponentInChildren<TextMeshProUGUI>();
				}
				return _textMesh;
			}
		}

		[SerializeField]
		private Image _iconImage;
		internal Image iconImage {
			get {
				if(_iconImage == null)
					_iconImage = GetComponentInChildren<Image>();
				return _iconImage;
			}
		}

		/// <summary>
		/// public getter / setter for the button's text component's text
		/// </summary>
		public string text {
			get {
				return textMesh.text;
			}
			set {
				textMesh.text = value;
			}
		}

		/// <summary>
		/// public getter / setter for the room icon
		/// </summary>
		public Sprite icon {
			get {
				return iconImage.sprite;
			}
			set {
				iconImage.sprite = value;
			}
		}

		// Object Methods: ------------------------------------------------------------------------

	}

	[System.Serializable]
	public struct RoomConstructionData {
		public string name;
		public int wood;
		public int metal;
		public float time;
	}
}