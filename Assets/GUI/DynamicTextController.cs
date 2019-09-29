using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public class DynamicTextController : MonoBehaviour {

		// Properties and Fields: ------------------------------------------------------------------------

		// the `SerializeField` attribute is used to ensure that the field shows up in the unity inspector, where it will be set, even though it's marked as private,
		// and the `Tooltip` attribute adds a tooltip to the field in the unity inspector when the user hovers over it with their mouse
		[SerializeField, Tooltip("The TextMeshPro UGUI object that this dynamic text controller will be modifying")] 
		private TextMeshProUGUI _valueField = default;

		// a public getter for the value field so that other scripts can access the valueField property
		public TextMeshProUGUI valueField => _valueField;

		// Object Methods: -------------------------------------------------------------------------------

		/// <summary>
		/// this will be used to update the dynamic text value
		/// </summary>
		protected virtual void onUpdate() {

			// this sets the dynamic text value to display the currently selected grid cell
			// NOTE: Normally you shouldn't call FindObjectOfType<>() unless inside an initialization method but I 
			// figured it's fine here since it's just being used for demonstration purposes
			valueField.text = FindObjectOfType<BuildGridController>().mouseTile.ToString();
		}

		// Unity Defined Callback Methods: ---------------------------------------------------------------

		/// <summary>
		/// this function is called every frame before the the camera renders the scene and the UI elements
		/// </summary>
		private void Update() {
			onUpdate();
		}
	}
}