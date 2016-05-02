﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegExp
{
    public partial class InputValidatorForm : Form
    {
        public InputValidatorForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!Regex.IsMatch(txtName.Text, @"^([A-Za-z]*\s*)*$"))
            if (!Regex.IsMatch(txtName.Text, @"^([A-Z][a-z].*\ [A-Z][a-z].*\s*)*$"))
                MessageBox.Show("The name is invalid (at least two names and only alphabetical characters are allowed in right case format!)");

            //if (!Regex.IsMatch(txtPhone.Text, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$"))
            if (!Regex.IsMatch(txtPhone.Text, @"^((\(\d{3}\).?)|(\d{3}-)).?\d{3}-\d{4}$"))
                MessageBox.Show("The phone number is not a valid US phone number!");

            //if (!Regex.IsMatch(txtEmail.Text, @"^([a-zA-Z0-9_\-” [email protected]\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9_\.\-]+@[a-zA-Z0-9_]+\.[a-zA-Z0-9]{2,4}$"))
                MessageBox.Show("The e-mail address is not valid!");

            txtPhone.Text = ReformatPhone(txtPhone.Text);
        }

        static string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
           
            return String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
        }
    }
}
