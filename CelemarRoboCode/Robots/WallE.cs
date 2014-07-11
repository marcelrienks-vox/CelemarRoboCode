using System.Drawing;
using Robocode;

namespace Celemar.Robocode.Robots
{
    public class WallE : MyAdvancedRobot
    {
        /// <summary>
        ///     The main method in every robot
        /// </summary>
        public override void Run()
        {
            //initialise Robot
            InitialiseRobot();

            //Start locked scan for targets
            Targeting.UnlockedScanForTarget();
        }

        /// <summary>
        ///     Initialises the robot.
        /// </summary>
        public override void InitialiseRobot()
        {
            //Set colours
            SetColors(Color.Orange, Color.DarkSlateGray, Color.LightGray, Color.Red, Color.LightGreen);

            //Unlock radar from gun from robot
            IsAdjustRadarForGunTurn = true;
            IsAdjustRadarForRobotTurn = true;
            IsAdjustGunForRobotTurn = true;
        }

        /// <summary>
        ///     Processes the scanned robot.
        /// </summary>
        /// <param name="targetHeading"></param>
        /// <param name="targetVelocity"></param>
        /// <param name="targetBearing"></param>
        private void ProcessScannedRobot(double targetHeading, double targetVelocity, double targetBearing)
        {
            TargetScanned = true;

            //Turn in parallel with target synchronously
            //Navigation.MoveInParallelWithTarget(targetHeading);

            //Turn in parallel with target asynchronously
            //Navigation.SetMoveInParallelWithTarget(targetHeading);
            //Execute();

            //Maintain lock on target
            Targeting.LockOnToTarget(targetBearing);

            //Keep scanning for target
            //Targeting.OscillateScan(targetBearing);


            Fire(5);
        }

        #region Events

        /// <summary>
        ///     Called when [scanned robot].
        /// </summary>
        /// <param name="e">The e.</param>
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            ProcessScannedRobot(e.Heading, e.Velocity, e.Bearing);
        }

        #endregion
    }
}