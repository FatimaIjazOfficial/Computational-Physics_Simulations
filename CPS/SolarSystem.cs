using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class SolarSystem
    {
        // Two-Body Problem (Array)
        public void DrawTwoBodyArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            Graphics gg = form.CreateGraphics();

            SolidBrush sun = new SolidBrush(Color.Orange);
            SolidBrush earth = new SolidBrush(Color.Green);
            SolidBrush border = new SolidBrush(Color.Black);

            gg.FillEllipse(sun, W - 25, H - 25, 80, 80); // Draw Sun

            int size = 20000;
            double dt = 0.0002, pi = Math.PI, beta = 2, r;
            double[] vx = new double[size], vy = new double[size];
            double[] x = new double[size], y = new double[size];

            x[0] = 1; y[0] = 0; vx[0] = 0; vy[0] = 2 * pi;

            for (int i = 0; i < size - 1; i++)
            {
                r = Math.Sqrt(x[i] * x[i] + y[i] * y[i]);
                vx[i + 1] = vx[i] - 4 * pi * pi * x[i] * dt / Math.Pow(r, beta + 1);
                vy[i + 1] = vy[i] - 4 * pi * pi * y[i] * dt / Math.Pow(r, beta + 1);
                x[i + 1] = x[i] + vx[i + 1] * dt;
                y[i + 1] = y[i] + vy[i + 1] * dt;

                gg.FillEllipse(earth, W + (float)(x[i] * 100), H + (float)(y[i] * 100), 40, 40);
                gg.FillEllipse(border, W + (float)(x[i] * 100), H + (float)(y[i] * 100), 40, 40);
            }
        }

        // Two-Body Problem (Without Array)
        public void DrawTwoBodyWithoutArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            Graphics gg = form.CreateGraphics();

            SolidBrush sun = new SolidBrush(Color.Orange);
            SolidBrush earth = new SolidBrush(Color.Green);
            SolidBrush border = new SolidBrush(Color.Black);

            gg.FillEllipse(sun, W - 25, H - 25, 80, 80);

            double dt = 0.0002, pi = Math.PI, beta = 2, r;
            double vx = 0, vy = 2 * pi, x = 1, y = 0;

            for (int i = 0; i < 20000 - 1; i++)
            {
                r = Math.Sqrt(x * x + y * y);
                vx -= 4 * pi * pi * x * dt / Math.Pow(r, beta + 1);
                vy -= 4 * pi * pi * y * dt / Math.Pow(r, beta + 1);
                x += vx * dt; y += vy * dt;

                gg.FillEllipse(earth, W + (float)(x * 100), H + (float)(y * 100), 40, 40);
                gg.FillEllipse(border, W + (float)(x * 100), H + (float)(y * 100), 40, 40);
            }
        }

        // Three-Body Problem (Array)
        public void DrawThreeBodyArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            Graphics gg = form.CreateGraphics();

            SolidBrush sun = new SolidBrush(Color.Orange);
            SolidBrush earth = new SolidBrush(Color.Green);
            SolidBrush jupiter = new SolidBrush(Color.Red);
            SolidBrush border = new SolidBrush(Color.Black);

            gg.FillEllipse(sun, W - 25, H - 25, 80, 80); // Sun

            int size = 60000;
            double dt = 0.0002, pi = Math.PI, beta = 2;
            double mj = 1.9e27, me = 6e24, ms = 2e30;
            double mjms = mj / ms, mems = me / ms;

            double[] Vxe = new double[size], Vye = new double[size];
            double[] Vxj = new double[size], Vyj = new double[size];
            double[] xe = new double[size], ye = new double[size];
            double[] xj = new double[size], yj = new double[size];

            xe[0] = 1; ye[0] = 0;
            xj[0] = 0; yj[0] = 5.2;
            Vxe[0] = 0; Vye[0] = 2 * pi;
            Vxj[0] = 2.74; Vyj[0] = 0;

            double re, rj, rej;

            for (int i = 0; i < size - 1; i++)
            {
                re = Math.Sqrt(xe[i] * xe[i] + ye[i] * ye[i]);
                rj = Math.Sqrt(xj[i] * xj[i] + yj[i] * yj[i]);
                rej = Math.Sqrt((xj[i] - xe[i]) * (xj[i] - xe[i]) + (yj[i] - ye[i]) * (yj[i] - ye[i]));

                Vxe[i + 1] = Vxe[i] - 4 * pi * pi * xe[i] * dt / Math.Pow(re, beta + 1) - 4 * pi * pi * mjms * (xj[i] - xe[i]) * dt / Math.Pow(rej, beta + 1);
                Vye[i + 1] = Vye[i] - 4 * pi * pi * ye[i] * dt / Math.Pow(re, beta + 1) - 4 * pi * pi * mjms * (yj[i] - ye[i]) * dt / Math.Pow(rej, beta + 1);
                Vxj[i + 1] = Vxj[i] - 4 * pi * pi * xj[i] * dt / Math.Pow(rj, beta + 1) - 4 * pi * pi * mems * (xj[i] - xe[i]) * dt / Math.Pow(rej, beta + 1);
                Vyj[i + 1] = Vyj[i] - 4 * pi * pi * yj[i] * dt / Math.Pow(rj, beta + 1) - 4 * pi * pi * mems * (yj[i] - ye[i]) * dt / Math.Pow(rej, beta + 1);

                xe[i + 1] = xe[i] + Vxe[i + 1] * dt; ye[i + 1] = ye[i] + Vye[i + 1] * dt;
                xj[i + 1] = xj[i] + Vxj[i + 1] * dt; yj[i + 1] = yj[i] + Vyj[i + 1] * dt;

                gg.FillEllipse(earth, W + (float)(xe[i] * 200), H + (float)(ye[i] * 200), 40, 40);
                gg.FillEllipse(border, W + (float)(xe[i] * 200), H + (float)(ye[i] * 200), 40, 40);
                gg.FillEllipse(jupiter, W + (float)(xj[i] * 50), H + (float)(yj[i] * 50), 40, 40);
                gg.FillEllipse(border, W + (float)(xj[i] * 50), H + (float)(yj[i] * 50), 40, 40);
            }
        }

        // Three-Body Problem (Without Array)
        public void DrawThreeBodyWithoutArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            Graphics gg = form.CreateGraphics();

            SolidBrush sun = new SolidBrush(Color.Orange);
            SolidBrush earth = new SolidBrush(Color.Green);
            SolidBrush jupiter = new SolidBrush(Color.Red);

            gg.FillEllipse(sun, W - 25, H - 25, 80, 80); // Sun

            int size = 60000;
            double dt = 0.0002, pi = Math.PI, beta = 2;
            double mj = 1.9e27, me = 6e24, ms = 2e30;
            double mjms = mj / ms, mems = me / ms;

            double Vxe = 0, Vye = 2 * pi, Vxj = 2.74, Vyj = 0;
            double xe = 1, ye = 0, xj = 0, yj = 5.2;
            double re, rj, rej;

            for (int i = 0; i < size - 1; i++)
            {
                re = Math.Sqrt(xe * xe + ye * ye);
                rj = Math.Sqrt(xj * xj + yj * yj);
                rej = Math.Sqrt((xj - xe) * (xj - xe) + (yj - ye) * (yj - ye));

                Vxe -= 4 * pi * pi * xe * dt / Math.Pow(re, beta + 1) - 4 * pi * pi * mjms * (xj - xe) * dt / Math.Pow(rej, beta + 1);
                Vye -= 4 * pi * pi * ye * dt / Math.Pow(re, beta + 1) - 4 * pi * pi * mjms * (yj - ye) * dt / Math.Pow(rej, beta + 1);
                Vxj -= 4 * pi * pi * xj * dt / Math.Pow(rj, beta + 1) - 4 * pi * pi * mems * (xj - xe) * dt / Math.Pow(rej, beta + 1);
                Vyj -= 4 * pi * pi * yj * dt / Math.Pow(rj, beta + 1) - 4 * pi * pi * mems * (yj - ye) * dt / Math.Pow(rej, beta + 1);

                xe += Vxe * dt; ye += Vye * dt;
                xj += Vxj * dt; yj += Vyj * dt;

                gg.FillEllipse(earth, W + (float)(xe * 200), H + (float)(ye * 200), 2, 2);
                gg.FillEllipse(jupiter, W + (float)(xj * 50), H + (float)(yj * 50), 2, 2);
            }
        }
    }
}
