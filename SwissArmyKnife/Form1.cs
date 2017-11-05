using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SwissArmyKnife
{
    public partial class Form1 : Form
    {
        decimal cogs;
        decimal price;
        decimal margin;
        int subscribers;
        decimal pricePerSub;
        decimal cogsPerSub;


        public Form1()
        {
            InitializeComponent();
            getInput();
            recalc();
            redraw();
        }

        #region margin_calc_section

        private void getInput()
        {
            cogs = Convert.ToDecimal(txtCOGS.Text);
            price = Convert.ToDecimal(txtPrice.Text);
            margin = Convert.ToDecimal(txtMargin.Text);
            subscribers = Convert.ToInt32(txtSubscribers.Text);
        }
        
        private void recalc()
        {
            pricePerSub = price / subscribers;
            cogsPerSub = cogs / subscribers;
        }
        
        private void redraw()
        {
            txtPrice.Text = price.ToString();
            txtCOGS.Text = cogs.ToString();
            txtMargin.Text = margin.ToString("F");
            txtPricePerSub.Text = pricePerSub.ToString("F");
            txtCogsPerSub.Text = cogsPerSub.ToString("F");
        }

        private void btnCalculateCOGS_Click(object sender, EventArgs e)
        {
            getInput();
            cogs = price * (1 - (margin/100));
            recalc();
            redraw();
        }

        private void btnCalculatePrice_Click(object sender, EventArgs e)
        {
            getInput();
            price = cogs / (1 - (margin / 100));
            recalc();
            redraw();
        }

        private void btnCalculateMargin_Click(object sender, EventArgs e)
        {
            getInput();
            margin = (1 - (cogs / price)) * 100;
            recalc();
            redraw();
        }
        #endregion

        // Calculator Code Starts Here

        double total1 = 0;
        double total2 = 0;
        double mem1 = 0;
        double mem2 = 0;
        double mem3 = 0;
        int last_operator = (int)lastOperator.None;
        public enum lastOperator : int
        {
            None, Plus, Minus, Multiply, Divide
        }
        bool operatorClicked = false;

        #region Number_buttons
        private void btnZero_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnZero.Text;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnOne.Text;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnTwo.Text;
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnThree.Text;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnFour.Text;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnFive.Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnSix.Text;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnSeven.Text;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnEight.Text;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnNine.Text;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (operatorClicked)
            {
                txtDisplay.Clear();
                operatorClicked = false;
            } 
            txtDisplay.Text = txtDisplay.Text + btnPoint.Text;
        }
        #endregion


        private void btnEquals_Click(object sender, EventArgs e)
        {
            calculate();
            txtDisplay.Text = total2.ToString("n");
            total1 = 0;
            last_operator = (int)lastOperator.None;
            operatorClicked = true;
        }

        #region operator_buttons
        private void btnPlus_Click(object sender, EventArgs e)
        {
            calculate();
            txtDisplay.Text = total2.ToString("n");
            total1 = total2;
            last_operator = (int)lastOperator.Plus;
            operatorClicked = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            calculate();
            txtDisplay.Text = total2.ToString("n");
            total1 = total2;
            last_operator = (int)lastOperator.Minus;
            operatorClicked = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            calculate();
            txtDisplay.Text = total2.ToString("n");
            total1 = total2;
            last_operator = (int)lastOperator.Multiply;
            operatorClicked = true;
        }

        private void btnDevede_Click(object sender, EventArgs e)
        {
            calculate();
            txtDisplay.Text = total2.ToString("n");
            total1 = total2;
            last_operator = (int)lastOperator.Divide;
            operatorClicked = true;
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            //txtDisplay.Text = btnZero.Text;
        }


        private void btnAllClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Clear();
            //txtDisplay.Text = btnZero.Text;
            total1 = 0;
            total2 = 0;
            last_operator = (int)lastOperator.None;
            operatorClicked = false;
        }

        #region margin_pulldowns
        private void button1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtPrice.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtCOGS.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtMargin.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtSubscribers.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtPricePerSub.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtCogsPerSub.Text;
        }
        #endregion

        #region user_defined_methods

        private void calculate()
        {
            switch (last_operator)
            {
                case (int)lastOperator.Plus:
                    total2 = total1 + double.Parse(txtDisplay.Text);
                    break;
                case (int)lastOperator.Minus:
                    total2 = total1 - double.Parse(txtDisplay.Text);
                    break;
                case (int)lastOperator.Multiply:
                    total2 = total1 * double.Parse(txtDisplay.Text);
                    break;
                case (int)lastOperator.Divide:
                    total2 = total1 / double.Parse(txtDisplay.Text);
                    break;
                case (int)lastOperator.None:
                    total2 = double.Parse(txtDisplay.Text);
                    break;
            }
        }

        #endregion

        #region Memories

        private void btnMem1_Click(object sender, EventArgs e)
        {
            mem1 = double.Parse(txtDisplay.Text);
            txtMem1.Text = txtDisplay.Text;
        }

        private void btnClrMem1_Click(object sender, EventArgs e)
        {
            mem1 = 0;
            txtMem1.Text = "0";
        }

        private void btnMem1Write_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtMem1.Text;
        }

        private void btnMem2_Click(object sender, EventArgs e)
        {
            mem2 = double.Parse(txtDisplay.Text);
            txtMem2.Text = txtDisplay.Text;
        }

        private void btnClrMem2_Click(object sender, EventArgs e)
        {
            mem2 = 0;
            txtMem2.Text = "0";
        }

        private void btnMem2Write_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtMem2.Text;
        }

        private void btnMem3_Click(object sender, EventArgs e)
        {
            mem3 = double.Parse(txtDisplay.Text);
            txtMem3.Text = txtDisplay.Text;
        }

        private void btnClrMem3_Click(object sender, EventArgs e)
        {
            mem3 = 0;
            txtMem3.Text = "0";
        }

        private void btnMem3Write_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtMem3.Text;
        }
        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.Show();
        }
    }
}
