using Celemar.Robocode.Robots;

namespace Celemar.Robocode.Libraries
{
    public class Targeting
    {
        #region Properties

        private readonly MyAdvancedRobot _myRobot;
        private int ScanDirection = -1;

        #endregion

        /// <summary>
        ///     Initializes a new instance of the <see cref="Targeting" /> class.
        /// </summary>
        /// <param name="myRobot">The robot.</param>
        public Targeting(MyAdvancedRobot myRobot)
        {
            _myRobot = myRobot;
        }

        /// <summary>
        ///     Unlocked Scan for target.
        ///     This performs a 45 degree sweep to the left, then sweeps right at 45 degree increments.
        ///     NOTE: this is an unlocking scan, other operations can be executed between right sweeps
        /// </summary>
        public void UnlockedScanForTarget()
        {
            //Sweep 45 degrees to the left
            _myRobot.TurnRadarLeft(45);

            //Sweep right by 45 degrees each time
            while (!_myRobot.TargetScanned)
            {
                _myRobot.TurnRadarRight(45);
            }
        }

        /// <summary>
        ///     Locked Scan for target.
        ///     This performs a 45 degree sweep to the left, then sweeps a Full 360 to the right from the original position.
        ///     NOTE: this is a locking scan, no other operations can be executed while the 360 degree sweep is executing
        /// </summary>
        public void LockedScanForTarget()
        {
            //Sweep 45 degrees to the left
            _myRobot.TurnRadarLeft(45);

            //Sweep 360 degrees to the right (405 degrees compensates for the 45 degree left sweep)
            _myRobot.TurnRadarRight(405);
        }

        /// <summary>
        ///     Locks the on to target.
        ///     When a target is scanned, the radar sweeps around in the oposite direction only by 10 degrees.
        ///     This will hopefully maintain a lock on the target.
        ///     This is best used with a single enemy.
        /// </summary>
        /// <param name="targetBearing">The bearing.</param>
        public void LockOnToTarget(double targetBearing)
        {
            //Lock on to target
            _myRobot.TurnRadarRight(_myRobot.Heading - _myRobot.RadarHeading + targetBearing);

            //swap scan direction
            ScanDirection *= -1;

            //scan
            _myRobot.TurnRadarLeft(10*ScanDirection);
        }

        /// <summary>
        ///     Oscillates the scan.
        ///     When a target is scanned, the radar sweeps around in the oposite direction a full 360 degrees.
        ///     This will allow other potentially closer targets to be scanned.
        ///     This is best used with multiple enemies.
        /// </summary>
        /// <param name="targetBearing">The bearing.</param>
        public void OscillateScan(double targetBearing)
        {
            //Lock on to target
            _myRobot.TurnRadarRight(_myRobot.Heading - _myRobot.RadarHeading + targetBearing);

            //swap scan direction
            ScanDirection *= -1;

            //scan
            _myRobot.TurnRadarLeft(360*ScanDirection);
        }
    }
}