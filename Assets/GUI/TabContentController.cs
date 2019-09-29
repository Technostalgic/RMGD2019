using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD{
	public class TabContentController : MonoBehaviour {

		// Properties and Fields: -----------------------------------------------------------------

		public bool isOpen => gameObject.activeSelf;

		// Object Methods: ------------------------------------------------------------------------

		public void Open() {
			gameObject.SetActive(true);
		}

		public void Close() {
			gameObject.SetActive(false);
		}
	}
}