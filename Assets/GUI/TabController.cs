using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD{
	public class TabController : MonoBehaviour {

		// Properties and Fields: -----------------------------------------------------------------

		private TabContainerController _parentContainer;
		public TabContainerController parentContainer {
			get {
				if(_parentContainer == null) {
					findParentContainer();
				}
				return _parentContainer;
			}
		}

		[SerializeField]
		private TabContentController _associatedTabContent = default;
		public TabContentController associatedTabContent => _associatedTabContent;

		// Object Methods: ------------------------------------------------------------------------

		private void findParentContainer() {
			_parentContainer = transform.parent.parent.GetComponent<TabContainerController>();
		}

		/// <summary>
		/// this is called from the button components 'OnClick' event. Select the tab game object in the unity
		/// project and see the inspector for the button component
		/// </summary>
		public void OnSelectTab() {
			parentContainer.SelectTab(this);
		}
	}
}