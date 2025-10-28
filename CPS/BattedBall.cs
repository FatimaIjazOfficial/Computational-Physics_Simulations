using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class BattedBall
    {
        // Batted Ball (Array)
        public void DrawArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");
            SolidBrush sb = new SolidBrush(Color.Purple);
            Graphics gg = form.CreateGraphics();

            int size = 1500;
            double g = 9.8, dt = 0.1, del = 5, vd = 35;
            double[] Vx = new double[size], x = new double[size];
            double[] Vy = new double[size], y = new double[size];
            double[] bm = new double[size], V = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                x[0] = 0; y[0] = 0; V[0] = 700;
                Vx[0] = V[0] * Math.Cos(th * Math.PI / 180);
                Vy[0] = V[0] * Math.Sin(th * Math.PI / 180);

                for (int i = 0; i < size - 1; i++)
                {
                    V[i + 1] = Math.Sqrt(Vx[i] * Vx[i] + Vy[i] * Vy[i]);
                    bm[i + 1] = 0.0039 + 0.0058 / (1 + Math.Exp((V[i] - vd) / del));
                    Vx[i + 1] = Vx[i] - bm[i] * V[i] * Vx[i] * dt;
                    Vy[i + 1] = Vy[i] - g * dt - bm[i] * V[i] * Vy[i] * dt;
                    x[i + 1] = x[i] + Vx[i] * dt;
                    y[i + 1] = y[i] + Vy[i] * dt;

                    if (y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + x[i] / 2), (float)(H - y[i] / 2), 5, 5);
                }
            }
        }

        // Batted Ball (Without Array)
        public void DrawWithoutArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");
            SolidBrush sb = new SolidBrush(Color.Purple);
            Graphics gg = form.CreateGraphics();

            for (int th = 35; th < 60; th += 5)
            {
                double g = 9.8, dt = 0.1, del = 5, vd = 35;
                double V = 700, Vx = V * Math.Cos(th * Math.PI / 180), Vy = V * Math.Sin(th * Math.PI / 180);
                double x = 0, y = 0, bm;

                for (int i = 0; i < 1499; i++)
                {
                    V = Math.Sqrt(Vx * Vx + Vy * Vy);
                    bm = 0.0039 + 0.0058 / (1 + Math.Exp((V - vd) / del));
                    Vx -= bm * V * Vx * dt;
                    Vy -= g * dt + bm * V * Vy * dt;
                    x += Vx * dt;
                    y += Vy * dt;

                    if (y < 1) break;

                    gg.FillEllipse(sb, (float)(W + x / 2), (float)(H - y / 2), 5, 5);
                }
            }
        }

        // Batted Ball (Isothermal)
        public void DrawIsothermal(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");
            SolidBrush sb = new SolidBrush(Color.Purple);
            Graphics gg = form.CreateGraphics();

            int size = 1500;
            double g = 9.8, dt = 0.1, del = 5, vd = 35, y0 = 10000;
            double[] Vx = new double[size], x = new double[size];
            double[] Vy = new double[size], y = new double[size];
            double[] bm = new double[size], V = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                x[0] = 0; y[0] = 0; V[0] = 700;
                Vx[0] = V[0] * Math.Cos(th * Math.PI / 180);
                Vy[0] = V[0] * Math.Sin(th * Math.PI / 180);

                for (int i = 0; i < size - 1; i++)
                {
                    V[i + 1] = Math.Sqrt(Vx[i] * Vx[i] + Vy[i] * Vy[i]);
                    bm[i + 1] = 0.0039 + 0.0058 / (1 + Math.Exp((V[i] - vd) / del));
                    Vx[i + 1] = Vx[i] - bm[i] * V[i] * Vx[i] * dt * Math.Exp(-y[i] / y0);
                    Vy[i + 1] = Vy[i] - g * dt - bm[i] * V[i] * Vy[i] * dt * Math.Exp(-y[i] / y0);
                    x[i + 1] = x[i] + Vx[i] * dt;
                    y[i + 1] = y[i] + Vy[i] * dt;

                    if (y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + x[i] / 2), (float)(H - y[i] / 2), 5, 5);
                }
            }
        }

        // Batted Ball (Adiabatic)
        public void DrawAdiabatic(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");
            SolidBrush sb = new SolidBrush(Color.Purple);
            Graphics gg = form.CreateGraphics();

            int size = 1500;
            double g = 9.8, dt = 0.1, del = 5, T = 288.15, vd = 35, a = 6.5e-3, alpha = 2.5;
            double[] Vx = new double[size], x = new double[size];
            double[] Vy = new double[size], y = new double[size];
            double[] bm = new double[size], V = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                x[0] = 0; y[0] = 0; V[0] = 700;
                Vx[0] = V[0] * Math.Cos(th * Math.PI / 180);
                Vy[0] = V[0] * Math.Sin(th * Math.PI / 180);

                for (int i = 0; i < size - 1; i++)
                {
                    V[i + 1] = Math.Sqrt(Vx[i] * Vx[i] + Vy[i] * Vy[i]);
                    bm[i + 1] = 0.0039 + 0.0058 / (1 + Math.Exp((V[i] - vd) / del));
                    Vx[i + 1] = Vx[i] - bm[i] * V[i] * Vx[i] * dt * Math.Pow((1 - a * y[i] / T), alpha);
                    Vy[i + 1] = Vy[i] - g * dt - bm[i] * V[i] * Vy[i] * dt * Math.Pow((1 - a * y[i] / T), alpha);
                    x[i + 1] = x[i] + Vx[i] * dt;
                    y[i + 1] = y[i] + Vy[i] * dt;

                    if (y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + x[i] / 2), (float)(H - y[i] / 2), 5, 5);
                }
            }
        }
    }
}
