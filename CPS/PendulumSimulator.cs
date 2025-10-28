using System;
using System.Drawing;

namespace CPS
{
    public class PendulumSimulator
    {
        private Graphics g;

        public PendulumSimulator(Graphics graphics)
        {
            g = graphics;
        }

        // ------------------------------
        // Common Function: Draw Axes
        // ------------------------------
        public void DrawAxis(PointF origin, string sx, string sy)
        {
            Pen p1 = new Pen(Color.Purple, 3);
            p1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Font f = new Font("Arial", 14);
            SolidBrush sb = new SolidBrush(Color.DarkGreen);

            // X-axis
            g.DrawLine(p1, origin.X, origin.Y, origin.X + 500, origin.Y);
            g.DrawString(sx, f, sb, origin.X + 250, origin.Y + 10);

            // Y-axis
            g.DrawLine(p1, origin.X, origin.Y, origin.X, origin.Y - 150);
            g.DrawString(sy, f, sb, origin.X - 80, origin.Y - 40);
        }

        // ------------------------------
        // IDEAL CASE (EULER)
        // ------------------------------
        public void IdealEuler(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * theta[i] * dt) / l, false, Color.Blue);
        }

        // ------------------------------
        // EULER CROMER
        // ------------------------------
        public void IdealEulerCromer(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * theta[i] * dt) / l, true, Color.Green);
        }

        // ------------------------------
        // SMALL ANGLE
        // ------------------------------
        public void SmallAngle(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * Math.Sin(theta[i]) * dt) / l, false, Color.SeaGreen);
        }

        // ------------------------------
        // DAMPING (EULER)
        // ------------------------------
        public void DampingEuler(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * theta[i] * dt) / l - q * w[i] * dt, false, Color.Green);
        }

        // ------------------------------
        // DRIVING (EULER)
        // ------------------------------
        public void DrivingEuler(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * theta[i] * dt) / l - q * w[i] * dt + fd * Math.Sin(wd * t[i]) * dt, false, Color.Aqua);
        }

        // ------------------------------
        // NONLINEAR (EULER)
        // ------------------------------
        public void NonLinearEuler(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * Math.Sin(theta[i]) * dt) / l - q * w[i] * dt + fd * Math.Sin(wd * t[i]) * dt, false, Color.Yellow);
        }

        // ------------------------------
        // DAMPING (EULER-CROMER)
        // ------------------------------
        public void DampingEulerCromer(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * theta[i] * dt) / l - q * w[i] * dt, true, Color.Blue);
        }

        // ------------------------------
        // DRIVING (EULER-CROMER)
        // ------------------------------
        public void DrivingEulerCromer(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * theta[i] * dt) / l - q * w[i] * dt + fd * Math.Sin(wd * t[i]) * dt, true, Color.Red);
        }

        // ------------------------------
        // NONLINEAR (EULER-CROMER)
        // ------------------------------
        public void NonLinearEulerCromer(PointF origin1, PointF origin2)
        {
            Simulate(origin1, origin2, (theta, w, t, gval, l, dt, q, fd, wd, i) =>
                w[i] - (gval * Math.Sin(theta[i]) * dt) / l - q * w[i] * dt + fd * Math.Sin(wd * t[i]) * dt, true, Color.DarkGoldenrod);
        }

        // ------------------------------------------------------------------
        // Common Simulation Core for All Cases
        // ------------------------------------------------------------------
        private void Simulate(PointF origin1, PointF origin2,
     Func<double[], double[], double[], double, double, double, double, double, double, int, double> wNextFunc,
     bool eulerCromer, Color color)
        {
            int size = 1000;
            double[] theta = new double[size];
            double[] w = new double[size];
            double[] t = new double[size];
            double gval = 9.8, l = 2, dt = 0.04, q = 0.5, fd = 0.2, wd = 2.0;

            SolidBrush sb = new SolidBrush(color);
            w[0] = 0.2;

            //Dynamic scaling based on window size
            float scaleX = (float)(origin1.X + 0.8 * (g.VisibleClipBounds.Width - origin1.X)) / (float)(t.Length * dt);
            float scaleY = 80; // vertical stretch

            for (int i = 0; i < size - 1; i++)
            {
                w[i + 1] = wNextFunc(theta, w, t, gval, l, dt, q, fd, wd, i);

                if (eulerCromer)
                    theta[i + 1] = theta[i] + w[i + 1] * dt;
                else
                    theta[i + 1] = theta[i] + w[i] * dt;

                t[i + 1] = t[i] + dt;

                // Keep theta bounded
                if (theta[i + 1] > Math.PI)
                    theta[i + 1] -= 2 * Math.PI;
                if (theta[i + 1] < -Math.PI)
                    theta[i + 1] += 2 * Math.PI;

                //Bound-check to stay inside window
                float x1 = (float)(origin1.X + scaleX * t[i]);
                float y1 = (float)(origin1.Y - scaleY * theta[i]);
                float x2 = (float)(origin2.X + scaleX * t[i]);
                float y2 = (float)(origin2.Y - scaleY * w[i]);

                if (x1 < 0 || x1 > g.VisibleClipBounds.Width - 10) break;
                if (x2 < 0 || x2 > g.VisibleClipBounds.Width - 10) break;
                if (y1 < 0 || y2 < 0) continue; // skip points off top

                g.FillEllipse(sb, x1, y1, 5, 5);
                g.FillEllipse(sb, x2, y2, 5, 5);
            }
        }

    }
}
