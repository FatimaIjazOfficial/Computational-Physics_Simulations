using System;
using System.Drawing;
using System.Windows.Forms;

namespace CPS
{
    public class LorenzModel
    {
        private readonly double sigma = 10.0, r = 25.0, b = 8.0 / 3.0;
        private readonly double dt = 0.0009;
        private readonly int size = 30000;

        public void PlotXvsT(Form form) => Plot(form, Color.Red, (t, x, y, z) => (t, x), 1.0, 0.0, 0.0);
        public void PlotYvsT(Form form) => Plot(form, Color.Blue, (t, x, y, z) => (t, y), 0.0, 1.0, 0.0); 
        public void PlotZvsT(Form form) => Plot(form, Color.Green, (t, x, y, z) => (t, z), 1.0, 0.0, 0.0);
        public void PlotYvsX(Form form) => Plot(form, Color.Yellow, (t, x, y, z) => (x, y), 1.0, 0.0, 0.0);
        public void PlotZvsX(Form form) => Plot(form, Color.Orange, (t, x, y, z) => (x, z), 1.0, 0.0, 0.0);
        public void PlotXvsY(Form form) => Plot(form, Color.Purple, (t, x, y, z) => (y, x), 0.0, 1.0, 0.0);
        public void PlotZvsY(Form form) => Plot(form, Color.Brown, (t, x, y, z) => (y, z), 0.0, 1.0, 0.0);
        public void PlotXvsZ(Form form) => Plot(form, Color.HotPink, (t, x, y, z) => (z, x), 1.0, 0.0, 0.0);
        public void PlotYvsZ(Form form) => Plot(form, Color.Gold, (t, x, y, z) => (z, y), 0.0, 1.0, 0.0);
       
        private void Plot(Form form, Color color,
                  Func<double, double, double, double, (double X, double Y)> valueSelector,
                  double x0, double y0, double z0)
        {
            float margin = 40f;
            float W = form.ClientSize.Width;
            float H = form.ClientSize.Height;
            float plotWidth = W - 2 * margin;
            float plotHeight = H - 2 * margin;

            double[] x = new double[size];
            double[] y = new double[size];
            double[] z = new double[size];
            double[] t = new double[size];

            x[0] = x0;
            y[0] = y0;
            z[0] = z0;

            // Precompute all values first
            for (int i = 0; i < size - 1; i++)
            {
                x[i + 1] = x[i] + sigma * (y[i] - x[i]) * dt;
                y[i + 1] = y[i] + (r * x[i] - y[i] - x[i] * z[i]) * dt;
                z[i + 1] = z[i] + (x[i] * y[i] - b * z[i]) * dt;
                t[i + 1] = t[i] + dt;
            }

            // Compute min/max for the axis
            double xMin = double.MaxValue, xMax = double.MinValue;
            double yMin = double.MaxValue, yMax = double.MinValue;

            for (int i = 0; i < size; i++)
            {
                var (valX, valY) = valueSelector(t[i], x[i], y[i], z[i]);
                if (valX < xMin) xMin = valX;
                if (valX > xMax) xMax = valX;
                if (valY < yMin) yMin = valY;
                if (valY > yMax) yMax = valY;
            }

            // Draw points scaled to fit the form
            using (Graphics gg = form.CreateGraphics())
            using (SolidBrush sb = new SolidBrush(color))
            {
                for (int i = 0; i < size; i++)
                {
                    var (valX, valY) = valueSelector(t[i], x[i], y[i], z[i]);
                    float px = margin + (float)((valX - xMin) / (xMax - xMin) * plotWidth);
                    float py = H - margin - (float)((valY - yMin) / (yMax - yMin) * plotHeight);
                    gg.FillEllipse(sb, px, py, 2, 2);
                }
            }
        }

    }
}
