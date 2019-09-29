using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public class RoomButtonTooltip : UITooltip {

		private RoomButtonController _roomButtonTarget;
		public RoomButtonController roomButtonTarget {
			get {
				if(_roomButtonTarget == null)
					_roomButtonTarget = GetComponent<RoomButtonController>();
				return _roomButtonTarget;
			}
		}

		public override string tooltip {
			get {

				string r = string.IsNullOrEmpty(base.tooltip) ? "" : base.tooltip + "\n";

				// set the tooltip to display the construction costs of the room
				r +=  roomButtonTarget.constructionData.name + "\n";
				r += "Wood Cost:" + roomButtonTarget.constructionData.wood.ToString() + "\n";
				r += "Metal Cost:" + roomButtonTarget.constructionData.metal.ToString() + "\n";
				r += "Construction Time:" + roomButtonTarget.constructionData.time.ToString() + " days";

				return r;
			}
		}
	}
}
