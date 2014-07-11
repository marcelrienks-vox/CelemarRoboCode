using Celemar.Robocode.Robots;

namespace Celemar.Robocode.Libraries
{
    public class Navigation
    {
        #region Properties

        private readonly MyAdvancedRobot _myRobot;

        #endregion

        /// <summary>
        ///     Initializes a new instance of the <see cref="Navigation" /> class.
        /// </summary>
        /// <param name="myRobot">My robot.</param>
        public Navigation(MyAdvancedRobot myRobot)
        {
            _myRobot = myRobot;
        }

        #region Public

        /// <summary>
        ///     Moves the Robot in parallel with target. These are locking moves.
        /// </summary>
        /// <param name="targetHeading">The target heading.</param>
        public void MoveInParallelWithTarget(double targetHeading)
        {
            //Calculate the angle to move Robot in parallel with target.
            var angle = Calculations.CalculateAngleToMoveInParallelWithTarget(targetHeading, _myRobot.Heading);

            //Turn in parallel
            _myRobot.TurnRight(angle);

            //Move with Target
            _myRobot.Ahead(double.PositiveInfinity);
        }

        /// <summary>
        ///     Sets the Move Robot in parallel with target. These are non locking moves.
        ///     This requires Execute() to be called after this function.
        /// </summary>
        /// <param name="targetHeading">The target heading.</param>
        public void SetMoveInParallelWithTarget(double targetHeading)
        {
            //Calculate the angle to move Robot in parallel with target.
            var angle = Calculations.CalculateAngleToMoveInParallelWithTarget(targetHeading, _myRobot.Heading);

            //Set Turn in parallel
            _myRobot.SetTurnRight(angle);

            //Set Move with Target
            _myRobot.SetAhead(double.PositiveInfinity);
        }

        /// <summary>
        ///     Bounces the Robot off the walls.
        /// </summary>
        /// <param name="wallBearing">The wall bearing.</param>
        public void BounceOffWalls(double wallBearing)
        {
            //If the wall is on the Robots Left, turn Right, else turn Left
            if (wallBearing < 0)
            {
                _myRobot.TurnRight(90);
            }
            else if (wallBearing > 0)
            {
                _myRobot.TurnLeft(90);
            }
            else
            {
                _myRobot.TurnRight(90);
            }

            //Move away from wall
            _myRobot.Ahead(double.PositiveInfinity);
        }

        #endregion
    }
}