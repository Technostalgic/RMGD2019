using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public class UITooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

		// Properties and Fields: -----------------------------------------------------------------

		// the textArea attribute creates a large text area in the unity inspector instead of the typical small text field
		[SerializeField, TextArea, Tooltip("The tooltip to display when the mouse hovers over this object")]
		private string _tooltip = default;

		public virtual string tooltip => _tooltip;

		// Interface Implementations: ---------------------------------------------------------

		/// <summary>
		/// implemented from <see cref="IPointerEnterHandler"/> and called back from the unity event system
		/// </summary>
		public void OnPointerEnter(PointerEventData eventData) {
			TooltipTextController.Show(tooltip);
		}

		/// <summary>
		/// implemented from <see cref="IPointerExitHandler"/> and called back from the unity event system
		/// </summary>
		public void OnPointerExit(PointerEventData eventData) {
			TooltipTextController.Hide();
		}
	}
}