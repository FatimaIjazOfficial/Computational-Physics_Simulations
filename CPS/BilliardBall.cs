using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class BilliardBall
    {
        public void DrawBilliardBall(Form1 form)
        {
            Graphics gg = form.CreateGraphics();

            Pen tableBorder = new Pen(Color.Red, 10);
            SolidBrush ball1 = new SolidBrush(Color.Blue);
            SolidBrush ball2 = new SolidBrush(Color.Brown);

            // Draw table
            gg.DrawRectangle(tableBorder, 100, 100, 800, 400);

            double vx = 1, vy = 1, dt = 0.2;
            int size = 10000;
            double[] x = new double[size];
            double[] y = new double[size];

            x[0] = 250;
            y[0] = 180;

            for (int i = 0; i < size - 1; i++)
            {
                x[i + 1] = x[i] + vx * dt;
                y[i + 1] = y[i] + vy * dt;

                // Collision with horizontal walls
                if (y[i + 1] > 490 || y[i + 1] < 110)
                {
                    vy = -vy;
                }

                // Collision with vertical walls
                if (x[i + 1] > 890 || x[i + 1] < 110)
                {
                    vx = -vx;
                }

                // Draw balls
                gg.FillEllipse(ball1, (float)x[i], (float)y[i], 5, 5);
                gg.FillEllipse(ball2, (float)x[i], (float)y[i], 5, 5);
            }
        }
    }
}
