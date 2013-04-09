using Robocode;

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

		//testing...
		public void MoveInParallel(double heading) {
			//testing...
			//Move in parallel
			Robot.TurnRight(heading);
		}
	}
}
