using Robocode;
using Robocode.Util;

namespace Celemar.Libraries {
	class Navigation {
		#region Properties
		private AdvancedRobot Robot = null;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Navigation"/> class.
		/// </summary>
		/// <param name="robot">The robot.</param>
		public Navigation(AdvancedRobot robot) {
			Robot = robot;
		}

		/// <summary>
		/// Moves the Robot in parallel with target.
		/// </summary>
		/// <param name="targetHeading">The target heading.</param>
		public void MoveInParallelWithTarget(double targetHeading) {
			//Get the difference in angle between robot and target
			var difference = targetHeading - Robot.Heading;

			//Normalize the difference
			var normalDifference = Utils.NormalRelativeAngleDegrees(difference);

			//Move in parallel
			Robot.TurnRight(normalDifference);

			//TODO: Move along with target
		}
	}
}
