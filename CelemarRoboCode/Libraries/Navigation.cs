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
		public void MoveInParallelWithTarget(double targetHeading, double targetVelocity) {
			//Get the difference in angle between robot and target
			var difference = targetHeading - MyRobot.Heading;

			//Normalize the difference
			var normalDifference = Utils.NormalRelativeAngleDegrees(difference);

			//Turn in parallel
			MyRobot.TurnRight(normalDifference);

			//Move with Target
			MyRobot.Ahead(targetVelocity);
		}

		/// <summary>
		/// Bounces the Robot off the walls.
		/// </summary>
		/// <param name="wallBearing">The wall bearing.</param>
		public void BounceOffWalls(double wallBearing) {
			//If the wall is on the Robots Right, turn Left, else turn Right
			if (wallBearing < 0) {
				MyRobot.TurnLeft(90);

			} else if (wallBearing > 0) {
				MyRobot.TurnRight(90);

			} else {
				MyRobot.TurnRight(90);
			}

			//Move away from wall
			MyRobot.Ahead(double.PositiveInfinity);
		}
	}
}
