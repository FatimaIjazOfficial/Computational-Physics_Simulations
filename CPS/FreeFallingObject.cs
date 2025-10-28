using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class FreeFallingObject
    {
        public void DrawHeight(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "Y"); // Use main form's drawaxis

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);
            int size = 150;
            double dt = 0.02, g = 9.8;
            double[] Vy = new double[size];
            double[] y = new double[size];
            double[] t = new double[size];
            Vy[0] = 50;
            y[0] = 0;
            t[0] = 0;

            for (int i = 0; i < Vy.Length - 1; i++)
            {
                Vy[i + 1] = Vy[i] - g * dt;
                y[i + 1] = y[i] - Vy[i] * dt;
                t[i + 1] = t[i] + dt;

                gg.FillEllipse(sb, (float)(W + t[i] * 150), (float)(H - y[i]), 5, 5);
            }
        }
        public void DrawDisplacement(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "Y"); // Use main form's drawaxis

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.DarkGreen);
            int size = 150;
            double dt = 0.02, g = 9.8;
            double[] Vy = new double[size];
            double[] y = new double[size];
            double[] t = new double[size];
            Vy[0] = 50;
            y[0] = 0;
            t[0] = 0;

            for (int i = 0; i < Vy.Length - 1; i++)
            {
                Vy[i + 1] = Vy[i] + g * dt;
                y[i + 1] = y[i] + Vy[i] * dt;
                t[i + 1] = t[i] + dt;
                if (y[i + 1] > 500) { break; } // or some limit
                gg.FillEllipse(sb, (float)(W + t[i] * 150), (float)(H - y[i]), 5, 5);
            }
        }
    }
}
