using System;
using System.Windows.Forms;

namespace CalcWFApp
{
    public partial class Calculator : Form
    {
        private ViewModel viewModel;

        public Calculator()
        {
            InitializeComponent();
            viewModel = new ViewModel();
        }

        void UpdateResult()
        {
            textBoxResult.Text = viewModel.Result;
            textBoxAction.Text = viewModel.ActionString;
            textBoxAction.SelectionStart = textBoxAction.Text.Length;
            textBoxAction.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(1);
            UpdateResult();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(2);
            UpdateResult();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(3);
            UpdateResult();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(4);
            UpdateResult();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(5);
            UpdateResult();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(6);
            UpdateResult();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(7);
            UpdateResult();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(8);
            UpdateResult();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(9);
            UpdateResult();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddDigit(0);
            UpdateResult();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddOperator(Operator.Plus);
            UpdateResult();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddOperator(Operator.Minus);
            UpdateResult();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddOperator(Operator.Multiply);
            UpdateResult();
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddOperator(Operator.Divide);
            UpdateResult();
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.OperatorEquals();
            UpdateResult();
        }

        private void buttonRoot_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.OperatorRoot();
            UpdateResult();
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.OperatorPercent();
            UpdateResult();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.RemoveDigit();
            UpdateResult();
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.PlusMinus();
            UpdateResult();
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            viewModel.C();
            UpdateResult();
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.C();
            }
            else
            {
                viewModel.CE();
            }

            UpdateResult();
        }

        private void buttonComma_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.AddComma();
            UpdateResult();
        }

        private void buttonOneX_Click(object sender, EventArgs e)
        {
            if (viewModel.IsHaveError)
            {
                viewModel.ShowError();
                return;
            }

            viewModel.OperatorOneX();
            UpdateResult();
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    button0_Click(null, new EventArgs());
                    break;
                case '1':
                    button1_Click(null, new EventArgs());
                    break;
                case '2':
                    button2_Click(null, new EventArgs());
                    break;
                case '3':
                    button3_Click(null, new EventArgs());
                    break;
                case '4':
                    button4_Click(null, new EventArgs());
                    break;
                case '5':
                    button5_Click(null, new EventArgs());
                    break;
                case '6':
                    button6_Click(null, new EventArgs());
                    break;
                case '7':
                    button7_Click(null, new EventArgs());
                    break;
                case '8':
                    button8_Click(null, new EventArgs());
                    break;
                case '9':
                    button9_Click(null, new EventArgs());
                    break;
                case '+':
                    buttonPlus_Click(null, new EventArgs());
                    break;
                case '-':
                    buttonMinus_Click(null, new EventArgs());
                    break;
                case '*':
                    buttonMultiply_Click(null, new EventArgs());
                    break;
                case '/':
                    buttonDivide_Click(null, new EventArgs());
                    break;
                case '%':
                    buttonPercent_Click(null, new EventArgs());
                    break;
                case '.':
                    buttonComma_Click(null, new EventArgs());
                    break;
                case ',':
                    buttonComma_Click(null, new EventArgs());
                    break;
                case '=':
                    buttonEquals_Click(null, new EventArgs());
                    break;
                case (char) Keys.Back:
                    buttonBack_Click(null, new EventArgs());
                    break;
            }
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                buttonCE_Click(null, new EventArgs());

            if(e.KeyCode == Keys.Escape)
                buttonC_Click(null, new EventArgs());
        }
    }
}
