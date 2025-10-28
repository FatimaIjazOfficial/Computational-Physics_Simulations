using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class Parachute
    {
        public void Draw(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "V");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            int size = 150;
            double dt = 0.1, a = 10, b = 1;
            double[] v = new double[size];
            double[] t = new double[size];
            v[0] = 150;
            t[0] = 0;

            for (int i = 0; i < v.Length - 1; i++)
            {
                v[i + 1] = v[i] + a * dt - b * v[i] * dt;
                t[i + 1] = t[i] + dt;
                if (Math.Abs(v[i + 1] - v[i]) < 0.001) break;

                gg.FillEllipse(sb, (float)(W + t[i] * 10), (float)(H - v[i]), 5, 5);
            }
        }
    }
}
