using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class CannonShell
    {
        // Ideal Case (No Drag)
        public void DrawIdeal(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Brown);
            int size = 1000;
            double dt = 0.1, g = 9.8, V;

            double[] Vx = new double[size];
            double[] Vy = new double[size];
            double[] X = new double[size];
            double[] Y = new double[size];
            double[] t = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                V = 700;
                X[0] = 0; Y[0] = 0;
                Vx[0] = V * Math.Cos(th * Math.PI / 180);
                Vy[0] = V * Math.Sin(th * Math.PI / 180);

                for (int i = 0; i < size - 1; i++)
                {
                    Vx[i + 1] = Vx[i];
                    Vy[i + 1] = Vy[i] - g * dt;
                    X[i + 1] = X[i] + Vx[i] * dt;
                    Y[i + 1] = Y[i] + Vy[i] * dt;
                    t[i + 1] = t[i] + dt;

                    if (Y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + X[i] / 150), (float)(H - Y[i] / 100), 5, 5);
                }
            }
        }

        // Real Case (With Air Drag)
        public void DrawReal(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Brown);
            int size = 1000;
            double dt = 0.1, g = 9.8, bm;
            double[] Vx = new double[size];
            double[] Vy = new double[size];
            double[] V = new double[size];
            double[] X = new double[size];
            double[] Y = new double[size];
            double[] t = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                X[0] = 0; Y[0] = 0;
                V[0] = 700;
                Vx[0] = V[0] * Math.Cos(th * Math.PI / 180);
                Vy[0] = V[0] * Math.Sin(th * Math.PI / 180);
                bm = 4e-5;

                for (int i = 0; i < size - 1; i++)
                {
                    V[i] = Math.Sqrt(Vx[i] * Vx[i] + Vy[i] * Vy[i]);
                    Vy[i + 1] = Vy[i] - g * dt - bm * V[i] * Vy[i] * dt;
                    Vx[i + 1] = Vx[i] - bm * V[i] * Vx[i] * dt;
                    Y[i + 1] = Y[i] + Vy[i] * dt;
                    X[i + 1] = X[i] + Vx[i] * dt;
                    t[i + 1] = t[i] + dt;

                    if (Y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + X[i] / 50), (float)(H - Y[i] / 50), 5, 5);
                }
            }
        }

        // Isothermal Case
        public void DrawIsothermal(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);
            int size = 1000;
            double dt = 0.1, g = 9.8, bm, y0 = 10000;
            double[] x = new double[size];
            double[] y = new double[size];
            double[] vx = new double[size];
            double[] vy = new double[size];
            double[] v = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                x[0] = 0; y[0] = 0;
                v[0] = 700;
                vx[0] = v[0] * Math.Cos(th * Math.PI / 180);
                vy[0] = v[0] * Math.Sin(th * Math.PI / 180);
                bm = 4e-5;

                for (int i = 0; i < size - 1; i++)
                {
                    v[i + 1] = Math.Sqrt(vx[i] * vx[i] + vy[i] * vy[i]);
                    x[i + 1] = x[i] + vx[i] * dt;
                    y[i + 1] = y[i] + vy[i] * dt;
                    vx[i + 1] = vx[i] - bm * v[i] * vx[i] * dt * Math.Exp(-y[i] / y0);
                    vy[i + 1] = vy[i] - g * dt - bm * v[i] * vy[i] * dt * Math.Exp(-y[i] / y0);

                    if (y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + x[i] / 50), (float)(H - y[i] / 50), 5, 5);
                }
            }
        }

        // Adiabatic Case
        public void DrawAdiabatic(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            form.drawaxis(new PointF(W, H), "X", "Y");

            Graphics gg = form.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);
            int size = 1000;
            double dt = 0.1, g = 9.8, bm, T = 288.15, a = 6.5e-3, alpha = 2.5;
            double[] x = new double[size];
            double[] y = new double[size];
            double[] vx = new double[size];
            double[] vy = new double[size];
            double[] v = new double[size];

            for (int th = 35; th < 60; th += 5)
            {
                x[0] = 0; y[0] = 0;
                v[0] = 700;
                vx[0] = v[0] * Math.Cos(th * Math.PI / 180);
                vy[0] = v[0] * Math.Sin(th * Math.PI / 180);
                bm = 4e-5;

                for (int i = 0; i < size - 1; i++)
                {
                    v[i + 1] = Math.Sqrt(vx[i] * vx[i] + vy[i] * vy[i]);
                    x[i + 1] = x[i] + vx[i] * dt;
                    y[i + 1] = y[i] + vy[i] * dt;
                    vx[i + 1] = vx[i] - bm * v[i] * vx[i] * dt * Math.Pow((1 - a * y[i] / T), alpha);
                    vy[i + 1] = vy[i] - g * dt - bm * v[i] * vy[i] * dt * Math.Pow((1 - a * y[i] / T), alpha);

                    if (y[i + 1] < 1) break;

                    gg.FillEllipse(sb, (float)(W + x[i] / 50), (float)(H - y[i] / 50), 5, 5);
                }
            }
        }
    }
}
