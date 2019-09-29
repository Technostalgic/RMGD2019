using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public class TabContainerController : MonoBehaviour {

		// Properties and Fields: -----------------------------------------------------------------

		public Color selectedTabColor;
		public Color unselectedTabColor;

		[SerializeField]
		private Transform _tabsContainer = default;
		public Transform tabsContainer => _tabsContainer;

		[SerializeField]
		private Transform _tabContentContainer = default;
		public Transform tabContentContainer => _tabContentContainer;

		private TabController[] _tabs;
		public TabController[] tabs {
			get {
				if(_tabs  == null) {
					findTabs();
				}
				return _tabs;
			}
		}

		private TabContentController[] _tabContents;
		public TabContentController[] tabContents {
			get {
				if(_tabContents == null)
					findTabContents();
				return _tabContents;
			}
		}

		// Object Methods: ------------------------------------------------------------------------

		private void findTabs() {

			// create a new array of TabControllers of size equal to the amount of children that the tabsContainer contains
			_tabs = new TabController[tabsContainer.childCount];

			// iterate through each child of the tabContainer and set the tab element inside `_tabs` to the tabController component on the child gameObject
			for(int i = tabsContainer.childCount - 1; i >= 0; i--) {
				_tabs[i] = tabsContainer.GetChild(i).GetComponent<TabController>();
			}
		}

		private void findTabContents() {

			// create a new array of TabContentController of size equal to the amount of children that the tabContentContainer contains
			_tabContents = new TabContentController[tabContentContainer.childCount];

			// iterate through each child of the tabContentContainer and set the tab element inside `_tabContents` to the tabContentController component on the child gameObject
			for(int i = tabContentContainer.childCount - 1; i >= 0; i--) {
				_tabContents[i] = tabContentContainer.GetChild(i).GetComponent<TabContentController>();
			}
		}

		private void setTabContentsInactive() {

			for(int i = tabContents.Length - 1; i>= 0; i--) {
				tabContents[i].gameObject.SetActive(false);
			}
		}

		public void SelectTab(TabController tab) {

			// iterate through each tabController object
			for(int i = tabs.Length - 1; i >= 0; i--) {

				// get the text component which is a child of the tabController object
				TextMeshProUGUI tmp = tabs[i].GetComponentInChildren<TextMeshProUGUI>();

				if(tabs[i] == tab) {
					// set the selected tab's color to the selectedTabColor
					tmp.color = selectedTabColor;
				}
				else {
					// set all the other tabs' text color to the unselectedTabColor
					tmp.color = unselectedTabColor;
				}
			}

			// iterate through each tabContentController object
			for(int i = tabContents.Length - 1; i >= 0; i--) {

				if(tab.associatedTabContent == tabContents[i]) {
					// open the tab contents that are associated with the specified tab
					tabContents[i].Open();
				}
				else if(tabContents[i].isOpen) {
					// close the tab contents if they are open, and aren't associated with the specified tab
					tabContents[i].Close();
				}
			}
		}

		// Unity Callback Methods: ----------------------------------------------------------------

		/// <summary>
		/// this is called at the very beginning of the gameObject's life, used for initialization
		/// </summary>
		private void Awake() {

			// initialize the tabs and tabContents arrays
			findTabs();
			findTabContents();
			setTabContentsInactive();
		}
	}
}