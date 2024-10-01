namespace Snowfall_simulation
{
    internal class Snowflake
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; init; }
        public int FallingSpeed { get; init; }

        public Snowflake(int x, int y, int size, int fallingSpeed)
        {
            X = x;
            Y = y;
            Size = size;
            FallingSpeed = fallingSpeed;
        }

        public void Fall()
        {
            Y += FallingSpeed;
        }
    }
}
