namespace StatefulUnitTestExercises
{
    /// <summary>
    /// An underwater, submersible vehicle.
    /// Includes two behaviors.
    /// Dive: go down a little deeper under water to a maximum depth
    /// Surface: come up a little shallower to a minimum depth of sea level
    /// 
    /// The submarine's current depth and pressure are available via properties.
    /// </summary>
    public class Submarine
    {
        private readonly double maxDepth;
        public double DepthInMeters { get; private set; }
        public double PressureInAtmospheres
        {
            get
            {
                // 3. At sea level, pressure is 1 atmosphere.
                // Pressure increases by 1 atmosphere for every 10 meters.
                return 0.0;
            }
        }

        public Submarine(double maxDepth)
        {
            this.maxDepth = maxDepth;
        }

        public void Dive()
        {
            // 1. Each Dive should increase the depth by 3 meters.
            // Depth cannot exceed maxDepth.
        }

        public void Surface()
        {
            // 2. Each Surface should decrease the depth by 5 meters.
            // Minimum depth is 0.0 (sea level).
        }
    }
}
