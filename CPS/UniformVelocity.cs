using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class UniformVelocity
    {
        public void Draw(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "X");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            int size = 150;
            double dt = 0.1, v = 40;
            double[] x = new double[size];
            double[] t = new double[size];
            x[0] = 150;
            t[0] = 0;

            for (int i = 0; i < x.Length - 1; i++)
            {
                x[i + 1] = x[i] - v * dt;
                t[i + 1] = t[i] + dt;
                if (x[i + 1] < 1) break;

                gg.FillEllipse(sb, (float)(W + t[i] * 10), (float)(H - x[i]), 5, 5);
            }
        }
    }
}
