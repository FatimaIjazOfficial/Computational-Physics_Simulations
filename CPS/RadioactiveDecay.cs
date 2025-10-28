using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class RadioactiveDecay
    {
        public void Draw(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "N"); // Use main form's drawaxis

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            int size = 150;
            double dt = 0.1, tou = 0.5;
            double[] N = new double[size];
            double[] t = new double[size];
            N[0] = 150;
            t[0] = 0;

            for (int i = 0; i < N.Length - 1; i++)
            {
                N[i + 1] = N[i] - tou * N[i] * dt;
                t[i + 1] = t[i] + dt;
                if (N[i + 1] < 1) break;

                gg.FillEllipse(sb, (float)(W + t[i] * 10), (float)(H - N[i]), 5, 5);
            }
        }
    }
}
