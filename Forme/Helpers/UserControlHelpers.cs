using Domen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Helpers
{
    public static class UserControlHelpers
    {
        public static bool EmptyFieldValidation(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.Maroon;
                return false;
            }
            else
            {
                txt.BackColor = Color.White;
                return true;
            }
        }
        public static bool TelefonFieldValidation(TextBox txt)
        {
            Regex telefon = new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}");
            {
                if (!telefon.IsMatch(txt.Text))
                {
                    txt.BackColor = Color.Maroon;
                    txt.Text = "";
                    return false;
                }
                else
                {
                    txt.BackColor = Color.White;
                    return true;
                }
            }

        }
       
        
    public static bool JmbgFieldValidation(TextBox txt)
        {
            if (txt.Text.Length != 13)
            {
                txt.BackColor = Color.Maroon;
                txt.Text = "";
                return false;
            }
            else
            {
                for (int i = 0; i < 13; i++)
                {
                    if (txt.Text[i] < 48 || txt.Text[i] > 57) {
                        txt.BackColor = Color.Maroon;
                        txt.Text = "";
                        return false;
                    }
                }
                txt.BackColor = Color.White;
                return true;
            }
        }

        public static bool IntValidation(TextBox txt)
        {
           if(!int.TryParse(txt.Text, out int _))
            {
                txt.BackColor = Color.IndianRed;
                return false;
            }
            else
            {
                txt.BackColor = Color.White;
                return true;
            }
        }

    }
}
