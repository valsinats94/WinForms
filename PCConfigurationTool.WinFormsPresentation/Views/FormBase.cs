using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCConfigurationTool.WinFormsPresentation.Views
{
    public class FormBase : Form
    {
        protected void txtNumericDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            string regionalDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
                && (e.KeyChar.ToString() != regionalDecimalSeparator))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar.ToString() == regionalDecimalSeparator) && ((sender as TextBox).Text.IndexOf(regionalDecimalSeparator) > -1))
            {
                e.Handled = true;
            }
        }

        protected bool ThumbnailCallback()
        {
            return false;
        }
    }
}
