using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions; // for regular expression
using System.Drawing; // for change of color
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace AppSecAssignment
{
    public partial class Registration : System.Web.UI.Page
    {
        private object lbl_pwdchecker;
        private readonly object tb_password;

        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["APPSECDBConnection"].ConnectionString;
        static string finalHash;
        static string salt;
        byte[] Key;
        byte[] IV;

        /*
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        */

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            //string pwd = get value from your Textbox
            string pwd = tb_password.ToString().Trim();

            //Generate random "salt"
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltByte = new byte[8];

            //Fills array of bytes with a cryptographically strong sequence of random values.
            rng.GetBytes(saltByte);
            salt = Convert.ToBase64String(saltByte);
            SHA512Managed hashing = new SHA512Managed();
            string pwdWithSalt = pwd + salt;
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            finalHash = Convert.ToBase64String(hashWithSalt);
            RijndaelManaged cipher = new RijndaelManaged();
            cipher.GenerateKey();
            Key = cipher.Key;
            IV = cipher.IV;
            //createAccount();
        }

        protected void btn_checkPassword_Click(object sender, EventArgs e)
        {
            // implement codes for the button event
            // Extract data from textbox
            int scores = checkPassword(tb_password);
            string status = "";
            switch (scores)
            {
                case 1:
                    status = "Very Weak";
                    break;
                case 2:
                    status = "Weak";
                    break;
                case 3:
                    status = "Medium";
                    break;
                case 4:
                    status = "Strong";
                    break;
                case 5:
                    status = "Excellent";
                    break;
                default:
                    break;
            }
            lbl_pwdchecker = "Status : " + status;
            if (scores < 4)
            {
                lbl_pwdchecker = Color.Red;
                return;
            }
            lbl_pwdchecker = Color.Green;
        }

        private int checkPassword(object tb_password)
        {
            throw new NotImplementedException();
        }

        /*
        private int checkPassword(object text)
        {
            throw new NotImplementedException();
        }
        */

        private int checkPassword(string password)
            {

                int score = 0;

                // Score 1 = Very Weak
                if (password.Length < 8)
                {
                    return 1;
                }
                else
                {
                    score = 1;
                }

                // Score 2 = Weak
                if (Regex.IsMatch(password, "[a-z]"))
                {
                    score = 2;
                }

                // Score 3 = Medium
                if (Regex.IsMatch(password, "[A-Z]"))
                {
                    score = 3;
                }

                // Score 4 = Strong
                if (Regex.IsMatch(password, "[0-9]"))
                {
                    score = 4;
                }

                // Score 5 = Excellent
                if (Regex.IsMatch(password, "[!@#$%^&*./]"))
                {
                    score = 5;
                }

                return score;

            }
        }
    }