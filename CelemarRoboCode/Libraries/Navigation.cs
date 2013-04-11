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

		#region Public
		/// <summary>
		/// Moves the Robot in parallel with target. These are locking moves.
		/// </summary>
		/// <param name="targetHeading">The target heading.</param>
		public void MoveInParallelWithTarget(double targetHeading) {
			//Calculate the angle to move Robot in parallel with target.
			var angle = Calculations.CalculateAngleToMoveInParallelWithTarget(targetHeading, MyRobot.Heading);

			//Turn in parallel
			MyRobot.TurnRight(angle);

			//Move with Target
			MyRobot.Ahead(double.PositiveInfinity);
		}

		/// <summary>
		/// Sets the Move Robot in parallel with target. These are non locking moves.
		/// This requires Execute() to be called after this function.
		/// </summary>
		/// <param name="targetHeading">The target heading.</param>
		public void SetMoveInParallelWithTarget(double targetHeading) {
			//Calculate the angle to move Robot in parallel with target.
			var angle = Calculations.CalculateAngleToMoveInParallelWithTarget(targetHeading, MyRobot.Heading);

			//Set Turn in parallel
			MyRobot.SetTurnRight(angle);

			//Set Move with Target
			MyRobot.SetAhead(double.PositiveInfinity);
		}

		/// <summary>
		/// Bounces the Robot off the walls.
		/// </summary>
		/// <param name="wallBearing">The wall bearing.</param>
		public void BounceOffWalls(double wallBearing) {
			//If the wall is on the Robots Left, turn Right, else turn Left
			if (wallBearing < 0) {
				MyRobot.TurnRight(90);

			} else if (wallBearing > 0) {
				MyRobot.TurnLeft(90);

			} else {
				MyRobot.TurnRight(90);
			}

			//Move away from wall
			MyRobot.Ahead(double.PositiveInfinity);
		}
		#endregion
	}
}
