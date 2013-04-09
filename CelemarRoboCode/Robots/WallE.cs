using System.Drawing;
using Celemar.Libraries;
using Robocode;

namespace Celemar {
	class WallE : AdvancedRobot {
		private Targeting targeting = null;

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
			//Access the Targeting library
			targeting = new Targeting(this);

			//Set colours
			SetColors(Color.Orange, Color.DarkSlateGray, Color.LightGray, Color.Red, Color.LightGreen);

			//Unlock radar from Gun
			IsAdjustRadarForGunTurn = true;
		}

		#region Events
		/// <summary>
		/// Called when [scanned robot].
		/// </summary>
		/// <param name="e">The e.</param>
		public override void OnScannedRobot(ScannedRobotEvent e) {
			//Maintain lock on target
			targeting.LockOnToTarget(e.Bearing);
		} 
		#endregion
	}
}
