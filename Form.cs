using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using org.mariuszgromada.math.mxparser;
namespace Lab2Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Function At;
        Expression expression;
        Argument x;
        private void построитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                At = new Function($"At(x) = {FunctionText.Text}");

                x = new Argument("x = 1");
                chart1.Series[0].Points.Clear();
                double a = Convert.ToDouble(ArgA.Text);
                double b = Convert.ToDouble(ArgB.Text);
                x.setArgumentValue(a);
                double y;
                expression = new Expression("At(x)", At, x);
                while (x.getArgumentValue() < b)
                {
                    y = expression.calculate();
                    chart1.Series[0].Points.AddXY(x.getArgumentValue(), y);
                    x.setArgumentValue(x.getArgumentValue() + 1f);
                    expression = new Expression("At(x)", At, x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены неправильные значения или функция");
            }

        }
        EventWaitHandle handle = new AutoResetEvent(false);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                xmintext.Text = "";
                chart1.Series[1].Points.Clear();
                a = Convert.ToDouble(ArgA.Text);
                b = Convert.ToDouble(ArgB.Text);
                E = Convert.ToDouble(ArgE.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введены неправильные значения или функция");
            }
        }
        double x1;
        double x2;
        double a;
        double b;
        double t = (Math.Sqrt(5) - 1) * 0.5;
        double E;
        void calculate()
        {
            x1 = b - t * (b - a);
            x2 = a + t * (b - a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Argument argX1;
            Argument argX2;
            if (E <= Math.Abs(b - a))
            {
                calculate();
                argX1 = new Argument($"x = {x1}");
                argX2 = new Argument($"x = {x2}");
                argX1.setArgumentValue(x1);
                argX2.setArgumentValue(x2);
                expression = new Expression("At(x)", At, argX1);
                double fx = expression.calculate();
                expression = new Expression("At(x)", At, argX2);
                double fx2 = expression.calculate();
                chart1.Series[1].Points.AddXY(x1, fx);
                chart1.Series[1].Points.AddXY(x2, fx2);
                if (fx >= fx2)
                    a = x1;
                else
                    b = x2;
                x1 = b - t * (b - a);
                x2 = a + t * (b - a);
            }
            else
            {
                xmintext.Text = $"{(a + b) * 0.5}";
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Argument argX1;
            Argument argX2;
            while (E <= Math.Abs(b - a))
            {
                calculate();
                argX1 = new Argument($"x = {x1}");
                argX2 = new Argument($"x = {x2}");
                argX1.setArgumentValue(x1);
                argX2.setArgumentValue(x2);
                expression = new Expression("At(x)", At, argX1);
                double fx = expression.calculate();
                expression = new Expression("At(x)", At, argX2);
                double fx2 = expression.calculate();
                chart1.Series[1].Points.AddXY(x1, fx);
                chart1.Series[1].Points.AddXY(x2, fx2);
                if (fx >= fx2)
                    a = x1;
                else
                    b = x2;
                x1 = b - t * (b - a);
                x2 = a + t * (b - a);
            }
                xmintext.Text = $"{(a + b) * 0.5}";
            
        }
    }
}
