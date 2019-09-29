using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public class ResearchRoomButtonController : MonoBehaviour {

		// Properties and Fields: -----------------------------------------------------------------

		[SerializeField]
		private RoomButtonController _roomButtonPrefab = default;

		[SerializeField, Tooltip("The scrollrect that the new room type buttons will be added under")]
		private ScrollRect _scrollRectTarget = default;

		// Object Methods: ------------------------------------------------------------------------

		/// <summary>
		/// this is called from the button component's 'OnClick' event. Select the research button in the unity
		/// project and see the inspector for the button component
		/// </summary>
		public void OnSelected() {
			AddNewRoomType();
		}

		public void AddNewRoomType() {

			// Instantiate a new instance of the _roomButtonPrefab into the scene
			RoomButtonController buttonInstance = Instantiate(_roomButtonPrefab);
			buttonInstance.text = "Room Type " + _scrollRectTarget.content.childCount;

			// set the construction costs to random values
			buttonInstance.constructionData.name = buttonInstance.text;
			buttonInstance.constructionData.wood = Random.Range(1, 10) * 50;
			buttonInstance.constructionData.metal = Random.Range(0, Random.Range(0, 10)) * 10;
			buttonInstance.constructionData.time = (float)Random.Range(3, 12) / 4;

			// Widen the scrollRect's content window to allow room for the new button
			_scrollRectTarget.content.sizeDelta += new Vector2(buttonInstance.rectTransform.rect.width, 0);

			// make the button instance a child of the _scrollRectTarget's content window
			buttonInstance.transform.SetParent(_scrollRectTarget.content);
		}
	}
}