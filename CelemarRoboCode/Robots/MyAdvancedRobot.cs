using Celemar.Robocode.Libraries;
using Robocode;

namespace Celemar.Robocode.Robots
{
    public abstract class MyAdvancedRobot : AdvancedRobot
    {
        #region Properties

        public Navigation Navigation = null;
        public Targeting Targeting = null;
        public bool TargetScanned { get; set; }

        #endregion

        /// <summary>
        ///     Initializes a new instance of the <see cref="MyAdvancedRobot" /> class.
        /// </summary>
        protected MyAdvancedRobot()
        {
            Targeting = new Targeting(this);
            Navigation = new Navigation(this);
        }

        #region Abstract

        public abstract void InitialiseRobot();

        #endregion
    }
}