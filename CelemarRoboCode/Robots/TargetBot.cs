using System.Drawing;
using Robocode;

namespace Celemar.Robots
{
    public class TargetBot : MyAdvancedRobot
    {
        /// <summary>
        ///     The main method in every robot
        /// </summary>
        public override void Run()
        {
            //initialise Robot
            InitialiseRobot();

            Ahead(double.PositiveInfinity);
        }

        /// <summary>
        ///     Initialises the robot.
        /// </summary>
        public override void InitialiseRobot()
        {
            //Set colours
            SetColors(Color.Black, Color.White, Color.Red);
        }

        /// <summary>
        ///     Processes the object hit.
        /// </summary>
        /// <param name="wallBearing">The wall bearing.</param>
        private void ProcessObjectHit(double wallBearing)
        {
            Navigation.BounceOffWalls(wallBearing);
        }

        #region Events

        /// <summary>
        ///     Called when [hit wall].
        /// </summary>
        /// <param name="e">The e.</param>
        public override void OnHitWall(HitWallEvent e)
        {
            ProcessObjectHit(e.Bearing);
        }

        /// <summary>
        ///     Called when [hit robot].
        /// </summary>
        /// <param name="e">The e.</param>
        public override void OnHitRobot(HitRobotEvent e)
        {
            ProcessObjectHit(e.Bearing);
        }

        #endregion
    }
}