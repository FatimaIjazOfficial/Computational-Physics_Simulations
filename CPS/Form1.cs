using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Refresh
        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        public void drawaxis(PointF origin, string sx, string sy)
        {
            Graphics gg = CreateGraphics();
            Pen p = new Pen(Color.Black, 4);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Font f = new Font("Times New Roman", 30);
            SolidBrush sb = new SolidBrush(Color.DarkSeaGreen);

            int xLength = 500;  // right
            int yLength = 300;  // up
            int tickLength = 10;
            int interval = 50;

            // X-axis
            gg.DrawLine(p, origin.X, origin.Y, origin.X + xLength, origin.Y);
            gg.DrawString(sx, f, sb, origin.X + xLength / 2, origin.Y + 10);

            // Y-axis
            gg.DrawLine(p, origin.X, origin.Y, origin.X, origin.Y - yLength);
            gg.DrawString(sy, f, sb, origin.X - 70, origin.Y - yLength / 2);

            // X-axis ticks
            for (int x = (int)origin.X + interval; x <= origin.X + xLength; x += interval)
                gg.DrawLine(p, x, origin.Y - tickLength / 2, x, origin.Y + tickLength / 2);

            // Y-axis ticks
            for (int y = (int)origin.Y; y >= origin.Y - yLength; y -= interval)
                gg.DrawLine(p, origin.X - tickLength / 2, y, origin.X + tickLength / 2, y);
        }

        void AfterDraw()
        {
            Bitmap bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            Graphics g2 = Graphics.FromImage(bmp);
            g2.CopyFromScreen(this.PointToScreen(Point.Empty), Point.Empty, this.ClientSize);

            string path = @"C:\Users\imaginators\Pictures\graph_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            MessageBox.Show("Graph saved successfully at:\n" + path, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Radioactive Decay
        private void radioActiveDecayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            RadioactiveDecay rd = new RadioactiveDecay();
            rd.Draw(this);
            AfterDraw();

        }

        // 1.1  FreeFallingObject

        //      FreeFallingObject(Height)
        private void heightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            FreeFallingObject ff = new FreeFallingObject();
            ff.DrawHeight(this);
            AfterDraw();
        }

        //      FreeFallingObject(Displacement)
        private void displacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            FreeFallingObject ff = new FreeFallingObject();
            ff.DrawDisplacement(this);
            AfterDraw();
        }

        // 1.2  Uniform Velocity
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Refresh();
            UniformVelocity uv = new UniformVelocity();
            uv.Draw(this);
            AfterDraw();
        }

        // 1.3  Parachute
        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            Parachute pa = new Parachute();
            pa.Draw(this);
            AfterDraw();
        }

        //1.4  One way Coupled
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Coupled c = new Coupled();
            c.DrawOneWay(this);
            AfterDraw();
        }

        //1.5  Two way Coupled
        private void toolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            Coupled c = new Coupled();
            c.DrawTwoWay(this);
            AfterDraw();
        }

        //1.6  Growth Population
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Refresh();
            GrowthPopulation gp = new GrowthPopulation();
            gp.Draw(this);
            AfterDraw();
        }


        //Realistic Projectile Motion                      


        //Bicycle Motion(Ideal Case)
        private void idealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Refresh(); // Clear previous drawing
            BicycleMotion bm = new BicycleMotion();
            bm.DrawIdeal(this);
            AfterDraw();
        }

        //Bicycle Motion(Real Case)
        private void realToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Refresh(); // Clear previous drawing
            BicycleMotion bm = new BicycleMotion();
            bm.DrawReal(this);
            AfterDraw();
        }

        //CanonShell(Ideal)(No Drag)
        private void idealToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            CannonShell cs = new CannonShell();
            cs.DrawIdeal(this);
            AfterDraw();
        }

        //CanonShell(Real)(With Air Drag)
        private void realToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            CannonShell cs = new CannonShell();
            cs.DrawReal(this);
            AfterDraw();
        }

        //CanonShell(Isothermal)
        private void isothermalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            CannonShell cs = new CannonShell();
            cs.DrawIsothermal(this);
            AfterDraw();
        }

        //CanonShell(Adiabatic)
        private void adiabaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            CannonShell cs = new CannonShell();
            cs.DrawAdiabatic(this);
            AfterDraw();
        }

        //Batted Ball(Array)
        private void arrayToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            BattedBall bb = new BattedBall();
            bb.DrawArray(this);
            AfterDraw();
        }

        //Batted Ball(Without Array)
        private void withoutArrayToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            BattedBall bb = new BattedBall();
            bb.DrawWithoutArray(this);
            AfterDraw();
        }

        //Batted Ball(IsoThermal)
        private void isoThermalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            BattedBall bb = new BattedBall();
            bb.DrawIsothermal(this);
            AfterDraw();
        }

        //Batted Ball(Adiabatic)
        private void adiabaticToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            BattedBall bb = new BattedBall();
            bb.DrawAdiabatic(this);
            AfterDraw();
        }


        //Solar System
        //TwoBodyProblem

        //Array
        private void arrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawTwoBodyArray(this);
        }
        //Without Array
        private void withoutArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawTwoBodyWithoutArray(this);
        }

        //ThreeBodyProblem

        //Array
        private void arrayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawThreeBodyArray(this);
        }
        //Without Array
        private void withoutArrayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawThreeBodyWithoutArray(this);
        }

        //BilliardBall
        private void billiardBallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            BilliardBall bb = new BilliardBall();
            bb.DrawBilliardBall(this);
            AfterDraw();
        }

        //  Lorentz Model    
        //Z Vs T
        private void zVsTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotZvsT(this);
            AfterDraw();
        }

        //Z vs X
        private void zVsXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotZvsX(this);
            AfterDraw();
        }

        //Z vs Y 
        private void zVsYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotZvsY(this);
            AfterDraw();
        }

        //X vs T
        private void xVsTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotXvsT(this);
            AfterDraw();
        }

        //X vs Y
        private void xVsYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotXvsY(this);
            AfterDraw();
        }

        //X vs Z
        private void xVsZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotXvsZ(this);
            AfterDraw();
        }

        //Y vs T
        private void yVsTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotYvsT(this);
            AfterDraw();
        }

        //Y vs X
        private void yVsXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotYvsX(this);
            AfterDraw();
        }

        //Y vs Z
        private void yVsZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            lm.PlotYvsZ(this);
            AfterDraw();
        }


        //Simple Pendulum

        private PointF origin1 => new PointF(ClientSize.Width / 8f, 2 * ClientSize.Height / 3f);
        private PointF origin2 => new PointF(ClientSize.Width / 8f, 2 * ClientSize.Height / 5f);

        private PendulumSimulator GetSimulator()
        {
            Graphics g = CreateGraphics();
            var sim = new PendulumSimulator(g);
            sim.DrawAxis(origin1, "t", "θ");
            sim.DrawAxis(origin2, "t", "ω");
            return sim;
        }

        //ideal Case by Euler
        private void eulerToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.IdealEuler(origin1, origin2);
            AfterDraw();
        }

        //ideal Case by Euler Cromer
        private void cromerToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.IdealEulerCromer(origin1, origin2);
            AfterDraw();
        }
        //For Smal Angle
        private void forSmallAngleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.SmallAngle(origin1, origin2);
            AfterDraw();
        }

        //RealisticCaseByEuler

        //Damping
        private void dampingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DampingEuler(origin1, origin2);
            AfterDraw();
        }
        //Driving
        private void drivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DrivingEuler(origin1, origin2);
            AfterDraw();
        }
        //Non Linear
        private void nonLinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.NonLinearEuler(origin1, origin2);
            AfterDraw();
        }

        //Realestic Case By Euler Cromer

        //Damping
        private void dampingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DampingEulerCromer(origin1, origin2);
            AfterDraw();
        }
        //Driving
        private void drivingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DrivingEulerCromer(origin1, origin2);
            AfterDraw();
        }
        //Non Linear
        private void nonLinearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.NonLinearEulerCromer(origin1, origin2);
            AfterDraw();
        }

    }
}
