using System.Drawing;
using Celemar.Libraries;
using Robocode;

namespace Celemar {
	class WallE : AdvancedRobot {
		private Targeting targeting = null;
		private Navigation navigation = null;

		/// <summary>
		/// The main method in every robot
		/// </summary>
		public override void Run() {
			//initialise Robot
			InitialiseRobot();

			//Start locked scan for targets
			targeting.LockedScanForTarget();
		}

		/// <summary>
		/// Initialises the robot.
		/// </summary>
		private void InitialiseRobot() {
			//Access the libraries
			targeting = new Targeting(this);
			navigation = new Navigation(this);

			//Set colours
			SetColors(Color.Orange, Color.DarkSlateGray, Color.LightGray, Color.Red, Color.LightGreen);

			//Unlock radar from Gun
			IsAdjustRadarForGunTurn = true;
		}

		/// <summary>
		/// Processes the scanned robot.
		/// </summary>
		/// <param name="bearing">The bearing.</param>
		private void ProcessScannedRobot(double targetHeading, double targetBearing) {
			//Move in parallel with target
			navigation.MoveInParallel(targetHeading);

			//Maintain lock on target
			targeting.LockOnToTarget(targetBearing);
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
