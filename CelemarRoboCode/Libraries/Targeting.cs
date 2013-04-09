using Robocode;

namespace Celemar.Libraries {
	class Targeting {
		#region Properties
		private AdvancedRobot Robot = null;
		private int ScanDirection = -1;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Targeting"/> class.
		/// </summary>
		/// <param name="robot">The robot.</param>
		public Targeting(AdvancedRobot robot) {
			Robot = robot;
		}

		/// <summary>
		/// Locked Scan for target.
		/// This performs a 45 degree sweep to the left, then sweeps right at 45 degree increments.
		/// NOTE: this is an unlocking scan, other operations can be executed between right sweeps
		/// </summary>
		public void UnlockedScanForTarget() {
			//Sweep 45 degrees to the left
			Robot.TurnRadarLeft(45);

			//Sweep right by 45 degrees each time
			while (true) {
				Robot.TurnRadarRight(45);
			}
		}

		/// <summary>
		/// Locked Scan for target.
		/// This performs a 45 degree sweep to the left, then sweeps a Full 360 to the right from the original position.
		/// NOTE: this is a locking scan, no other operations can be executed while the 360 degree sweep is executing
		/// </summary>
		public void LockedScanForTarget() {
			//Sweep 45 degrees to the left
			Robot.TurnRadarLeft(45);

			//Sweep 360 degrees to the right (405 degrees compensates for the 45 degree left sweep)
			Robot.TurnRadarRight(405);
		}

		/// <summary>
		/// Locks the on to target.
		/// When a target is scanned, the radar sweeps around in the oposite direction only by 10 degrees.
		/// This will hopefully maintain a lock on the target.
		/// This is best used with a single enemy.
		/// </summary>
		/// <param name="bearing">The bearing.</param>
		public void LockOnToTarget(double bearing) {
			//Lock on to target
			Robot.TurnRadarRight(Robot.Heading - Robot.RadarHeading + bearing);

			//swap scan direction
			ScanDirection *= -1;

			//scan
			Robot.TurnRadarLeft(10 * ScanDirection);
		}

		/// <summary>
		/// Oscillates the scan.
		/// When a target is scanned, the radar sweeps around in the oposite direction a full 360 degrees.
		/// This will allow other potentially closer targets to be scanned.
		/// This is best used with multiple enemies.
		/// </summary>
		/// <param name="bearing">The bearing.</param>
		public void OscillateScan(double bearing) {
			//Lock on to target
			Robot.TurnRadarRight(Robot.Heading - Robot.RadarHeading + bearing);

			//swap scan direction
			ScanDirection *= -1;

			//scan
			Robot.TurnRadarLeft(360 * ScanDirection);
		}
	}
}
