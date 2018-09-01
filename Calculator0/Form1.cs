/*
 * Calculator 0
 * By Erik Jepsen
 * For CSC-260-D30-2018FA
 * Dr. Jenkins
 * 
 * Rule #1 when coding: Comment your code as if the next person who must read your code is a homicidal maniac with a very low tolerance for frustration and your GPS coordinates at any given time. Managers are far less predictible and have the potential to be infinitly more scary!
 * 
 * Rule #2 when coding: Use the stuffed animal method of KISS coding. If you confuse yourself or stumble over your own words while explaining your code to a stuffed animal, it's probably too complicated and needs to be simplified. Remember, Teddy isn't judging you; your co-workers will.
 * 
*/
using System; // The System library is used in this program
using System.Windows.Forms; // So is this one.

namespace Calculator0 // We're making a new name for ourselves.
{
    public partial class Calculator : Form  // This partial class is a subset of the Forms class and inherits its functions.
    {
        /// <summary>
        /// Represents whether the TxtIOBox is in Input mode (true) or not (false).
        /// </summary>
        public bool InputMode;
        /// <summary>
        /// Represents whether the calculator is in Integer mode (false) or Decimal mode (true).
        /// </summary>
        public bool DecimalMode;
        /// <summary>
        /// This string represents the current decimal number as entered by the user. While in Decimal mode, this is kept up to date.
        /// </summary>
        public string DecimalNum;
        /// <summary>
        /// This is the current number entered by the user and is used for operations. While in Integer mode, this is kept up to date.
        /// </summary>
        public double? CurrentNum;
        /// <summary>
        /// This represents the first of two numbers, entered by the user, to be used in an operation.
        /// </summary>
        public double? StoredNum;
        /// <summary>
        /// This byte represents an operation queued for execution. If this value is greater than zero, StoredNum should also be set.
        /// </summary>
        public byte StoredOperand;
        /// <summary>
        /// This is the initializer function for this class.
        /// </summary>
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
        /// <summary>
        /// This is the handler for any time one of the ten arabic numerals on the calculator is pressed.
        /// </summary>
        /// <param name="sender">This is passed from the original button press event. It is not currently used by this function, but is here in case of future necessity.</param>
        /// <param name="e">This is passed from the original button press event. It is not currenly used but is here in case of future necessity.</param>
        /// <param name="BtnPressed">This integer represents the numeral selected by the button click.</param>
        private void _DigitBtn(object sender, EventArgs e, int BtnPressed)
        {
            if (InputMode) // If we're in Input Mode
            {
                if (((CurrentNum == 0) || !CurrentNum.HasValue) && !DecimalMode) // And if the current value is 0 or not assigned and we're not in Decimal mode.
                    CurrentNum = BtnPressed; //Set the current value equal to that of the button pressed.
                else // Otherwise...
                {
                    if (DecimalMode) // If we're in Decimal mode...
                    {
                        DecimalNum = DecimalNum + BtnPressed.ToString(); // Append the digit pressed to the current decimal number.
                        TxtIOBox1.Text = DecimalNum; // And update the display.
                    }
                    else // If we're in Integer mode and we know the value is not zero...
                    {
                        CurrentNum *= 10; // Shove everything to the left...
                        CurrentNum += BtnPressed; // And in-place add the number selected to CurrentNum.
                    }
                }
            }
            else // If we're in Output mode...
            {
                InputMode = true; // Switch to Input mode.
                DecimalMode = false; // Ensure Integer mode.
                DecimalNum = ""; // Clear any data in DecimalNum.
                CurrentNum = BtnPressed; // Set the current value to the number pressed.
            }
            if (!DecimalMode) // If we're in Integer mode
                TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
        }
        /// <summary>
        /// This function assigns the StoredOperand and StoredNum values based on the OperandNo passed and the CurrentNum.
        /// </summary>
        /// <param name="sender">This is passed by the button click function call and isn't used at this time. It is included in case it is needed in the future.</param>
        /// <param name="e">This is passed by the button click function call and isn't used at this time. It is included in case it is needed in the future.</param>
        /// <param name="OperandNo">This byte represents the operand selected by the button click.</param>
        private void _BtnOperandClick(object sender, EventArgs e, byte OperandNo)
        {
            if (StoredOperand > 0)  // If there is an operation already in the hopper...
                BtnEqual_Click(sender, e); // Execute it.
            StoredOperand = OperandNo; // Then copy the current operand being requested into the StoredOperand variable.
            InputMode = false; // Switch to Output mode.
            if (DecimalMode) // If we're in Decimal Mode
            {
                StoredNum = double.Parse(DecimalNum); // Parse the value of the Decimal number and copy it to StoredNum.
                TxtIOBox1.Text = StoredNum.ToString();  // Update the display. If there are trailing zeros on the decimal number, this will eliminate them.
            }
            else // If we're in Integer mode...
            {
                StoredNum = CurrentNum; // Copy the CurrentNum to the StoredNum
                TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
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
        /// <summary>
        /// This is the button click handler for the square root button.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            InputMode = false; // Switch to output mode.
            if (!CurrentNum.HasValue && !DecimalMode) // If CurrentNum has no value and we're in Integer mode.
                CurrentNum = 0; // Set it to zero.
            else // If CurrentNum has a value
            {
                if (DecimalMode) // If we're in Decimal mode...
                    CurrentNum = double.Parse(DecimalNum); // Parse the current decimal number to a double for this operation and store it in CurrentNum.
                CurrentNum = Math.Sqrt(CurrentNum.Value); // Do the square root operation on the CurrentNum value and store it back in CurrentNum.
                if ((CurrentNum.Value % 1) > 0) // If the new CurrentNum is not an integer...
                {
                    DecimalNum = CurrentNum.ToString(); // Copy the string value of the decimal to DecimalNum
                    DecimalMode = true; // Ensure Decimal Mode is on.
                    TxtIOBox1.Text = DecimalNum; // Update the display.
                }
                else // If the new CurrentNum is an integer...
                {
                    DecimalMode = false; // Ensure Integer Mode is on.
                    DecimalNum = ""; // Clear any value from the DecimalNum variable.
                    TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
                }
            }
        }
        /// <summary>
        /// This is the button click handler for the x^2 button.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnSquare_Click(object sender, EventArgs e)
        {
            InputMode = false; // Turn off Input mode.
            if (DecimalMode) // If we're in Decimal mode...
            {
                DecimalNum = Math.Pow(double.Parse(DecimalNum), 2).ToString(); // Parse the DecimalNum string to a double, square it with the Math.Pow() function, convert the result back to a string and store it back in DecimalNum.
                TxtIOBox1.Text = DecimalNum; // Update the display.
            }
            else // If we're in Integer mode...
            {
                CurrentNum = Math.Pow(CurrentNum.Value, 2); // Use the Math.Pow() function to square the value of CurrentNum and store it back in CurrentNum.
                TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
            }
        }
        #region Two Value Operands
        private void BtnPow_Click(object sender, EventArgs e)
        {
            _BtnOperandClick(sender, e, 1);
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
        #endregion
        /// <summary>
        /// This is the handler for the 1/x button click.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnOneOverX_Click(object sender, EventArgs e)
        {
            if (StoredOperand > 0) // If there's a stored operation pending...
                BtnEqual_Click(sender, e); // Execute it.
            InputMode = false; // Ensure we are in Output mode. 
            if (DecimalMode) // If we're in Decimal Mode...
            {
                DecimalNum = (1 / double.Parse(DecimalNum)).ToString(); // Parse the current value of DecimalNum, divide 1 by the resulting double, convert this double to a string and store it back in DecimalNum.
                TxtIOBox1.Text = DecimalNum; // Update the display.
            }
            else // If we're in Integer mode...
            {
                CurrentNum = 1 / CurrentNum.Value; // Divide one by the value of CurrentNum and store the result in CurrentNum.
                if ((CurrentNum.Value % 1) > 0) // If there is a remainder after dividing the current number by one, it's a decimal. If that is the case...
                {
                    DecimalMode = true; // Turn on Decimal mode.
                    DecimalNum = CurrentNum.ToString(); // Copy the current number as a string to DecimalNum.
                    TxtIOBox1.Text = DecimalNum; // Update the display.
                }
                else // If the new number isn't a decimal...
                    TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
            }
        }
        /// <summary>
        /// This is the button click handler for the CE button.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnCE_Click(object sender, EventArgs e)
        {
            CurrentNum = 0; // Set the current number to zero.
            DecimalNum = ""; // Clear the current DecimalNum, if any.
            DecimalMode = false; // Ensure Integer mode is on.
            TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
        }
        /// <summary>
        /// This is the button click handler for the Clear button.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnClear_Click(object sender, EventArgs e)
        {
            StoredNum = null;  // Clear the StoredNum value, if any.
            StoredOperand = 0; // Clear the StoredOperand value, if any.
            BtnCE_Click(sender, e); // Do everything the CE button does.
        }
        /// <summary>
        /// This is the Delete button click handler.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if(DecimalMode) // If we're in Decimal mode...
            {
                DecimalNum = DecimalNum.Remove((DecimalNum.Length-1), 1); // Determin the length of the DecimalNum variable. Subtract one from this number. Using the DecimalNum variable value, go to the index number we just calculaterd and remove one character. Store the resulting string back into DecimalNum.
                TxtIOBox1.Text = DecimalNum; // Update the display.
                if (!DecimalNum.Contains(".")) // If the DecimalNum no longer contains a decimal point...
                {
                    CurrentNum = double.Parse(DecimalNum); // Copy this number back into CurrentNum.
                    DecimalNum = ""; // Clear the DecimalNum string.
                    DecimalMode = false; // Turn on Integer mode.
                }
            }
            else // If we're in Integer mode...
            {
                int TempNum = 0; // Create a temporary variable for an integer.
                TempNum = (int) (CurrentNum % 10); // Get the value of the digit in the current "ones" place.
                CurrentNum -= TempNum; // Subtract that number from CurrentNum
                CurrentNum /= 10; // Divide CurrentNum by 10 to move everything right one place.
                TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
            }
        }
        /// <summary>
        /// This is the button click handler for the equal sign (=) button.
        /// </summary>
        /// <param name="sender">This value is passed by the system when the handler is called.</param>
        /// <param name="e">This value is passed by the system when the handler is called.</param>
        private void BtnEqual_Click(object sender, EventArgs e)
        {
            InputMode = false; // Ensure Output mode is on.
            if(DecimalMode) // If we're in Decimal mode...
            {
                CurrentNum = double.Parse(DecimalNum); // Parse the current number to a double and store it in the CurrentNum box.
                DecimalNum = ""; // Clear the value in the DecimalNum box.
                DecimalMode = false; // Ensure Integer mode is on.
            }
            if(StoredNum.HasValue && (StoredOperand > 0)) // If there is a StoredNum and the StoredOperand value is greater than zero...
            {
                switch(StoredOperand) // Depending on the value of StoredOperand...
                {
                    case 1: // If the value is one...
                        CurrentNum = Math.Pow(StoredNum.Value, CurrentNum.Value); // Raise the stored value to the power of the value in CurrentNum and store the result in CurrentNum.
                        break;
                    case 2: // If the value is two...
                        if (CurrentNum == 0) // And the value of CurrentNum is zero.
                            TxtIOBox1.Text = "Error"; // Update the display with an error message. We don't divide by zero in this house!
                        else // If the value is anything other than zero...
                            CurrentNum = StoredNum / CurrentNum; // Divide the value of the StoredNum by the value of the CurrentNum and store the result in CurrentNum.
                        break;
                    case 3: // If the value of StoredOperand is three...
                        CurrentNum *= StoredNum; // Do an in-place multiplication of the value of CurrentNum with the value of StoredNum.
                        break;
                    case 4: // If the value of StoredOperand is four...
                        CurrentNum = StoredNum - CurrentNum; // Subtract the value of the CurrentNum from the value of StoredNum and store the result in CurrentNum.
                        break;
                    case 5: // If the value of StoredOperand is five...
                        CurrentNum += StoredNum; // Do an in-place addition of the CurrentNum with the value of the StoredNum.
                        break;
                    default: // If the value of StoredOperand is anything else, and it shouldn't be...
                        // Oops. You did something I hadn't thought of. Shame on you!
                        break;
                }
                StoredNum = null; // Clear the value of the StoredNum.
            }
            else if (StoredOperand > 0) // If there's a StoredOperand value greater than zero, but no StoredNum...
            {
                switch(StoredOperand)
                {
                    case 1: // If the value of StoredOperand is one...
                        CurrentNum = Math.Pow(CurrentNum.Value, CurrentNum.Value); // Raise the value of the CurrentNum by the power of the value of the CurrentNum and store the result in CurrentNum. IOW, x^x and store in the same place you got x from.
                        break;
                    case 2: // If the value of StoredOperand is two...
                        CurrentNum = 1; // Any number divided by itself is always one, so set CurrentNum to one and carry on.
                        break;
                    case 3: // If the value of StoredOperand is three...
                        CurrentNum *= CurrentNum; // Do an in-place multiplication of the value of CurrentNum with itself and store the value in CurrentNum.
                        break;
                    case 4: // If the value of StoredOperand is four...
                        CurrentNum = 0; // Any number minus itself is zero. Set the value of CurrentNum to zero and continue.
                        break;
                    case 5: // If the value of StoredOperand is five...
                        CurrentNum += CurrentNum; // Do an in-place addition of the value of the CurrentNum with itself.
                        break;
                    default: // If the value of the StoredOperand is anything else...
                        // Oh! That's unexpected. Stop that!
                        break;
                }
            }
            StoredNum = null; // Ensure StoredNum is empty, because we're paranoid.
            StoredOperand = 0; // Reset the StoredOperand value to zero.
            TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
        }
        /// <summary>
        /// This is the button handler for the sign-swap button.
        /// </summary>
        /// <param name="sender">This is provided by the system at call time.</param>
        /// <param name="e">This is provided by the system at call time.</param>
        private void BtnSign_Click(object sender, EventArgs e)
        {
            if (DecimalMode && DecimalNum.StartsWith("-")) // If we're in Decimal mode and the current DecimalNum string starts with a minus sign...
            {
                DecimalNum = DecimalNum.TrimStart('-'); // Trim the - from the start of the DecimalNum string.
                TxtIOBox1.Text = DecimalNum; // Update the display.
            }
            else if (DecimalMode) // Otherwise, if Decimal Mode is on and the current DecimalNum string does not begin with a minus sign...
            {
                DecimalNum = '-' + DecimalNum; // Append a minus sign to the current value of the DecimalNum string.
                TxtIOBox1.Text = DecimalNum; // Update the display.
            }
            else if (CurrentNum != 0) // If we're in Integer mode, we don't care what the value of DecimalNum is, but we do want to check that the CurrentNum value isn't zero. If it isn't...
            {
                CurrentNum *= -1; // Do an in-place multiplication of the value of the CurrentNum value with negative one.
                TxtIOBox1.Text = CurrentNum.ToString(); // Update the display.
            }
        }
        /// <summary>
        /// This is the button handler for the decimal point button.
        /// </summary>
        /// <param name="sender">This is provided by the system at call time.</param>
        /// <param name="e">This is provided by the system at call time.</param>
        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            if (!InputMode)
            {
                BtnCE_Click(sender, e);
                InputMode = true;
            }  
            if (!DecimalMode) // If Decimal mode is not already on...
            {
                DecimalMode = true; // Turn on Decimal mode.
                DecimalNum = CurrentNum.ToString() + '.'; // Convert the CurrentNum value to a string, postpend a decimal and store in DecimalNum.
                TxtIOBox1.Text = DecimalNum; // Update the display.
            }
        }
    }
}