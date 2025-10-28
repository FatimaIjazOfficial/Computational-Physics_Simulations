using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class BicycleMotion
    {
        // Ideal Case
        public void DrawIdeal(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "V");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Brown);

            int size = 500;
            double p = 25, m = 70, dt = 0.1;
            double[] V = new double[size];
            double[] x = new double[size];
            double[] t = new double[size];

            V[0] = 4;

            for (int i = 0; i < V.Length - 1; i++)
            {
                V[i + 1] = V[i] + (p / (m * V[i])) * dt;
                x[i + 1] = x[i] + V[i] * dt;
                t[i + 1] = t[i] + dt;

                gg.FillEllipse(sb, (float)(W + t[i] * 10), (float)(H - V[i] * 10), 5, 5);
            }
        }

        // Real Case
        public void DrawReal(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "V");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Brown);

            int size = 500;
            double p = 25, p2 = 0.5, m = 70, dt = 0.1, A = 0.33;
            double[] V = new double[size];
            double[] x = new double[size];
            double[] t = new double[size];

            V[0] = 4;

            for (int i = 0; i < V.Length - 1; i++)
            {
                V[i + 1] = V[i] + (p / (m * V[i])) * dt - (1 / (2 * m)) * p2 * A * V[i] * V[i] * dt;
                x[i + 1] = x[i] + V[i] * dt;
                t[i + 1] = t[i] + dt;

                gg.FillEllipse(sb, (float)(W + t[i] * 10), (float)(H - V[i] * 10), 5, 5);
            }
        }
    }
}
