using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode.Util;

namespace Celemar.Libraries {
	public static class Calculations {

		#region Public
		/// <summary>
		/// Calculates the angle to move Robot in parallel with target.
		/// </summary>
		/// <param name="targetHeading">The target heading.</param>
		/// <param name="myRobotHeading">My robot heading.</param>
		public static double CalculateAngleToMoveInParallelWithTarget(double targetHeading, double myRobotHeading) {
			//Get the difference in angle between robot and target
			var difference = targetHeading - myRobotHeading;

			//Normalize the difference
			var normalDifference = Utils.NormalRelativeAngleDegrees(difference);

			//Return result
			return normalDifference;
		}
		#endregion
	}
}
