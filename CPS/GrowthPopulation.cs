using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class GrowthPopulation
    {
        public void Draw(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "N");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Brown);

            int size = 1000;
            double dt = 0.1, a = 10, b = 0.01;
            double[] N = new double[size];
            double[] t = new double[size];
            N[0] = 1000;

            for (int i = 0; i < N.Length - 1; i++)
            {
                N[i + 1] = N[i] + (a * N[i] - b * N[i] * N[i]) * dt;
                t[i + 1] = t[i] + dt;

                gg.FillEllipse(sb, (float)(W + t[i]), (float)(H - N[i]), 5, 5);
            }
        }
    }
}
