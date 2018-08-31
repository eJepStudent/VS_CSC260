using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Data;
// using System.Drawing;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator0
{
    public partial class Calculator : Form
    {
        public bool InputMode;
        public bool DecimalMode;
        public string DecimalNum;
        public double? CurrentNum;
        public double? StoredNum;
        public byte StoredOperand;
        public Calculator()
        {
            DecimalMode = false;
            InputMode = false;
            CurrentNum = 0;
            StoredNum = null;
            DecimalNum = "";
            StoredOperand = 0;
            InitializeComponent();
            TxtIOBox1.Text = "0";
        }
        private void _DigitBtn(object sender, EventArgs e, int BtnPressed)
        {
            if (InputMode)
            {
                if (CurrentNum == 0)
                {
                    CurrentNum = BtnPressed;
                }
                else
                {
                    if (DecimalMode)
                    {
                        DecimalNum = DecimalNum + BtnPressed.ToString();
                        TxtIOBox1.Text = DecimalNum;
                    }
                    else
                    {
                        CurrentNum *= 10;
                        CurrentNum += BtnPressed;
                    }
                }
            }
            else
            {
                InputMode = true;
                DecimalMode = false;
                CurrentNum = BtnPressed;
            }
            if (!DecimalMode)
                TxtIOBox1.Text = CurrentNum.ToString();
        }
        private void _BtnOperandClick(object sender, EventArgs e, byte OperandNo)
        {
            if (StoredOperand > 0)
            {
                BtnEqual_Click(sender, e);
            }
            StoredOperand = OperandNo;
            InputMode = false;
            if (DecimalMode)
            {
                StoredNum = double.Parse(DecimalNum);
                TxtIOBox1.Text = StoredNum.ToString();
            }
            else
            {
                StoredNum = CurrentNum;
                TxtIOBox1.Text = CurrentNum.ToString();
            }
        }
        #region Buttons zero thru nine
        private void BtnZero_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 0);
        }

        private void BtnOne_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 1);
        }

        private void BtnTwo_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 2);
        }

        private void BtnThree_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 3);
        }

        private void BtnFour_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 4);
        }

        private void BtnFive_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 5);
        }

        private void BtnSix_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 6);
        }

        private void BtnSeven_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 7);
        }

        private void BtnEight_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 8);
        }

        private void BtnNine_Click(object sender, EventArgs e)
        {
            _DigitBtn(sender, e, 9);
        }
        #endregion
        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            InputMode = false;
            if (CurrentNum == null)
            {
                CurrentNum = 0;
            }
            else
            {
                double TempNum = CurrentNum.Value;
                CurrentNum = Math.Sqrt(TempNum);
            }
            TxtIOBox1.Text = CurrentNum.ToString();
        }

        private void BtnSquare_Click(object sender, EventArgs e)
        {
            InputMode = false;
            if (DecimalMode)
            {
                DecimalNum = Math.Pow(double.Parse(DecimalNum), 2).ToString();
                TxtIOBox1.Text = DecimalNum;
            }
            else
            {
                CurrentNum = Math.Pow(CurrentNum.Value, 2);
                TxtIOBox1.Text = CurrentNum.ToString();
            }
        }

        private void BtnPow_Click(object sender, EventArgs e)
        {
            _BtnOperandClick(sender, e, 1);
        }

        private void BtnOneOverX_Click(object sender, EventArgs e)
        {
            if (StoredOperand > 0)
            {
                BtnEqual_Click(sender, e);
            }
            InputMode = false;
            if (DecimalMode)
            {
                DecimalNum = (1 / double.Parse(DecimalNum)).ToString();
                TxtIOBox1.Text = DecimalNum;
            }
            else
            {
                CurrentNum = 1 / CurrentNum;
                TxtIOBox1.Text = CurrentNum.ToString();
            }
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            CurrentNum = 0;
            DecimalNum = "";
            DecimalMode = false;
            TxtIOBox1.Text = CurrentNum.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            StoredNum = null;
            StoredOperand = 0;
            BtnCE_Click(sender, e);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if(DecimalMode)
            {
                //Do Stuff.
            }
            else
            {
                int TempNum = 0;
                TempNum = (int) (CurrentNum % 10);
                CurrentNum -= TempNum;
                CurrentNum /= 10;
            }
            TxtIOBox1.Text = CurrentNum.ToString();
        }

        private void BtnDivide_Click(object sender, EventArgs e)
        {
            _BtnOperandClick(sender, e, 2);
        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            _BtnOperandClick(sender, e, 3);
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            _BtnOperandClick(sender, e, 4);
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            _BtnOperandClick(sender, e, 5);
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            InputMode = false;
            if(DecimalMode)
            {
                // Do stuff.
            }
            else
            {
                if((StoredNum != null) && (StoredOperand > 0))
                {
                    switch(StoredOperand)
                    {
                        case 1:
                            CurrentNum = Math.Pow(StoredNum.Value, CurrentNum.Value);
                            break;
                        case 2:
                            CurrentNum = StoredNum / CurrentNum;
                            break;
                        case 3:
                            CurrentNum *= StoredNum;
                            break;
                        case 4:
                            CurrentNum = StoredNum - CurrentNum;
                            break;
                        case 5:
                            CurrentNum += StoredNum;
                            break;
                        default:
                            // Oops. You did something I hadn't thought of. Shame on you!
                            break;
                    }
                    StoredNum = null;
                }
                else if (StoredOperand > 0)
                {
                    switch(StoredOperand)
                    {
                        case 1:
                            CurrentNum = Math.Pow(CurrentNum.Value, CurrentNum.Value);
                            break;
                        case 2:
                            CurrentNum = 1;
                            break;
                        case 3:
                            CurrentNum *= CurrentNum;
                            break;
                        case 4:
                            CurrentNum = 0;
                            break;
                        case 5:
                            CurrentNum += CurrentNum;
                            break;
                        default:
                            // Oh! That's unexpected. Stop that!
                            break;
                    }
                }
            }
            StoredNum = null;
            StoredOperand = 0;
            TxtIOBox1.Text = CurrentNum.ToString();
        }

        private void BtnSign_Click(object sender, EventArgs e)
        {
            if (DecimalMode && DecimalNum.StartsWith("-"))
            {
                DecimalNum = DecimalNum.TrimStart('-');
                TxtIOBox1.Text = DecimalNum;
            }
            else if (DecimalMode)
            {
                DecimalNum = '-' + DecimalNum;
                TxtIOBox1.Text = DecimalNum;
            }
            else if (CurrentNum != 0)
            {
                CurrentNum *= -1;
                TxtIOBox1.Text = CurrentNum.ToString();
            }
        }

        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            if (!DecimalMode)
            {
                DecimalMode = true;
                DecimalNum = CurrentNum.ToString() + '.';
                TxtIOBox1.Text = DecimalNum;
            }
        }
    }
}