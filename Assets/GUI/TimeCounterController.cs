using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put the class inside our custom Namespace so it can access other scripts defined in this namespace
namespace RMGD {
	public sealed class TimeCounterController : DynamicTextController {

		/// <summary>
		/// since the <see cref="TimeCounterController"/> inherits most of it's functionality from <see cref="DynamicTextController"/>,
		/// all we need to do is override the <see cref="onUpdate"/> method so it's functionality differs from the base class
		/// </summary>
		protected override void onUpdate() {

			// calculate how many seconds have elapsed since the last minute
			int seconds = Mathf.FloorToInt(Time.time % 60);

			// calculate how many minutes have elapsed
			int minutes = Mathf.FloorToInt(Time.time / 60);

			// defines a blinking ':' character as the seperator, where the blink frequency is once per second
			string seperator = Time.time % 1 < 0.5f ? ":" : " ";

			// set the value field's text to the hours and minutes formatted as / minutes:seconds / 00:00
			valueField.text = minutes.ToString("D2") + seperator + seconds.ToString("D2");
		}
	}
}