using System.Drawing;
using Celemar.Libraries;
using Celemar.Robots;
using Robocode;

namespace Celemar.Robots {
	public class TargetBot : MyAdvancedRobot {

		/// <summary>
		/// The main method in every robot
		/// </summary>
		public override void Run() {
			//initialise Robot
			InitialiseRobot();

			Ahead(double.PositiveInfinity);
		}

		/// <summary>
		/// Initialises the robot.
		/// </summary>
		public override void InitialiseRobot() {
			//Set colours
			SetColors(Color.Black, Color.White, Color.Red);
		}

		#region Events

		#endregion
	}
}
