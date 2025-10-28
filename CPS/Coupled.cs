using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class Coupled
    {
        public void DrawOneWay(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "Na\n & \nNb");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb1 = new SolidBrush(Color.Brown);
            SolidBrush sb2 = new SolidBrush(Color.Green);

            int size = 150;
            double dt = 0.1, tou = 1;
            double[] Na = new double[size];
            double[] Nb = new double[size];
            double[] t = new double[size];
            Na[0] = 150;
            Nb[0] = 0;

            for (int i = 0; i < Na.Length - 1; i++)
            {
                Na[i + 1] = Na[i] + (-Na[i] / tou) * dt;
                Nb[i + 1] = Nb[i] + ((Na[i] / tou) - (Nb[i] / tou)) * dt;
                t[i + 1] = t[i] + dt;

                gg.FillEllipse(sb1, (float)(W + t[i] * 20), (float)(H - Na[i]), 5, 5);
                gg.FillEllipse(sb2, (float)(W + t[i] * 20), (float)(H - Nb[i]), 5, 5);
            }
        }

        public void DrawTwoWay(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            PointF origin = new PointF(W, H);

            form.drawaxis(origin, "T", "Na\n & \nNb");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb1 = new SolidBrush(Color.Brown);
            SolidBrush sb2 = new SolidBrush(Color.Green);

            int size = 150;
            double dt = 0.1, tou = 1;
            double[] Na = new double[size];
            double[] Nb = new double[size];
            double[] t = new double[size];
            Na[0] = 150;
            Nb[0] = 0;

            for (int i = 0; i < Na.Length - 1; i++)
            {
                Na[i + 1] = Na[i] + ((Nb[i] / tou) - (Na[i] / tou)) * dt;
                Nb[i + 1] = Nb[i] + ((Na[i] / tou) - (Nb[i] / tou)) * dt;
                t[i + 1] = t[i] + dt;

                gg.FillEllipse(sb1, (float)(W + t[i] * 20), (float)(H - Na[i]), 5, 5);
                gg.FillEllipse(sb2, (float)(W + t[i] * 20), (float)(H - Nb[i]), 5, 5);
            }
        }
    }
}
