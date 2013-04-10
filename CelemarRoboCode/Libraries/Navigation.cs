using Celemar.Robots;
using Robocode;
using Robocode.Util;

namespace Celemar.Libraries {
	public class Navigation {
		#region Properties
		private MyAdvancedRobot MyRobot = null;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Navigation" /> class.
		/// </summary>
		/// <param name="myRobot">My robot.</param>
		public Navigation(MyAdvancedRobot myRobot) {
			MyRobot = myRobot;
		}

		/// <summary>
		/// Moves the Robot in parallel with target.
		/// </summary>
		/// <param name="targetHeading">The target heading.</param>
		public void TurnInParallelWithTarget(double targetHeading) {
			//Get the difference in angle between robot and target
			var difference = targetHeading - MyRobot.Heading;

			//Normalize the difference
			var normalDifference = Utils.NormalRelativeAngleDegrees(difference);

			//Move in parallel
			MyRobot.TurnRight(normalDifference);
		}
	}
}
