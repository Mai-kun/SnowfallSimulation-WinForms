using Timer = System.Windows.Forms.Timer;

namespace Snowfall_simulation
{
    public partial class SnowfallForm : Form
    {
        private const int SnowflakeAmount = 100;

        private readonly Image snowflakeImage = Properties.Resources.Snowflake;
        private Snowflake[] snowflakes;
        private Timer timer;

        public SnowfallForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            InitializeSnowfall();

            InitializeTimer();
        }

        private void InitializeSnowfall()
        {
            Random random = new();
            snowflakes = new Snowflake[SnowflakeAmount];

            for (var i = 0; i < SnowflakeAmount; i++)
            {
                var size = random.Next(15, 35);
                var x = random.Next(0, Width);
                var y = random.Next(0, Height);
                var speed = random.Next(1, 5);

                snowflakes[i] = new Snowflake(x, y, size, speed);
            }
        }

        private void InitializeTimer()
        {
            timer = new Timer
            {
                Interval = 5
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Fall();
                if (IsOutOfBounds(snowflake))
                {
                    snowflake.Y = -20;
                    snowflake.X = new Random().Next(0, Width);
                }
            }

            Invalidate();
        }

        private bool IsOutOfBounds(Snowflake snowflake)
        {
            return snowflake.Y > Height;
        }

        private void SnowfallForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (var snowflake in snowflakes)
            {
                e.Graphics.DrawImage(snowflakeImage, snowflake.X, snowflake.Y, snowflake.Size, snowflake.Size);
            }
        }
    }
}
