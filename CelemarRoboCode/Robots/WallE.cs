using System.Drawing;
using Celemar.Libraries;
using Robocode;

namespace Celemar {
	class WallE : AdvancedRobot {
		private Targeting Targeting = null;
		private Navigation Navigation = null;

		/// <summary>
		/// The main method in every robot
		/// </summary>
		public override void Run() {
			//initialise Robot
			InitialiseRobot();

			//Start locked scan for targets
			Targeting.UnlockedScanForTarget();
		}

		/// <summary>
		/// Initialises the robot.
		/// </summary>
		private void InitialiseRobot() {
			//Initialise Libraries and Properties
			Targeting = new Targeting(this);
			Navigation = new Navigation(this);

			//Set colours
			SetColors(Color.Orange, Color.DarkSlateGray, Color.LightGray, Color.Red, Color.LightGreen);

			//Unlock radar from gun from robot
			IsAdjustRadarForGunTurn = true;
			IsAdjustRadarForRobotTurn = true;
			IsAdjustGunForRobotTurn = true;
		}

		/// <summary>
		/// Processes the scanned robot.
		/// </summary>
		/// <param name="bearing">The bearing.</param>
		private void ProcessScannedRobot(double targetHeading, double targetBearing) {
			//Move in parallel with target
			Navigation.MoveInParallelWithTarget(targetHeading);

			//Maintain lock on target
			Targeting.LockOnToTarget(targetBearing);
		}

		#region Events
		/// <summary>
		/// Called when [scanned robot].
		/// </summary>
		/// <param name="e">The e.</param>
		public override void OnScannedRobot(ScannedRobotEvent e) {
			ProcessScannedRobot(e.Heading, e.Bearing);
		} 
		#endregion
	}
}
