using System.Drawing;
using Robocode;

namespace Celemar {
	class WallE : Robot {
		public override void Run() {
			InitialiseRobot();
		}

		/// <summary>
		/// Initialises the robot.
		/// </summary>
		private void InitialiseRobot() {
			SetColors(Color.Orange, Color.DarkSlateGray, Color.LightGray, Color.Red, Color.LightGreen);
		}

		private void ScanForOpponent() {

		}
	}
}
