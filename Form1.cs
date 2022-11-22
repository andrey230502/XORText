using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOR_Text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void myShowToolTip(TextBox tb, byte[] arr)
        {
            string hexValues = BitConverter.ToString(arr);
            toolTip_HEX.SetToolTip(tb, hexValues);
            
        
        }
        byte[] myXOR(byte[] arr_text, byte[] arr_key)
        {
            int len_text = arr_text.Length;
            int len_key = arr_key.Length;
            byte[] arr_chiper = new byte[len_text];
            for (int i = 0; i < len_text; i++)
            {
                if (len_key == 0)
                {
                    textBox_C_IN.Text = textBox_P_IN.Text;
                }
                else
                {
                byte p = arr_text[i];
                byte k = arr_key[i % len_key];
                byte c = (byte)(p ^ k);
                arr_chiper[i] = c;
                }
               

            }
            return arr_chiper;
        }
        string myCipher(TextBox tb_text, TextBox tb_Key, TextBox tb_cipher, string cipher= "")
        {
            string text = tb_text.Text;
            byte[] arr_text;
            if (cipher == "") arr_text = Encoding.Unicode.GetBytes(text);
            else arr_text = Encoding.Unicode.GetBytes(cipher);
            myShowToolTip(tb_text, arr_text); // Створити підказку
            string key = tb_Key.Text;
            byte[] arr_key = Encoding.Unicode.GetBytes(key);
            myShowToolTip(tb_Key, arr_key); // Створити підказку
            byte[] arr_cipher = myXOR(arr_text, arr_key);
            //string cipher = BitConverter.ToString(arr_cipher).Replace(&quot;-&quot;, &quot;&quot;);
            cipher = Encoding.Unicode.GetString(arr_cipher);
            tb_cipher.Text = cipher;
            myShowToolTip(tb_cipher, arr_cipher); // Створити підказку
            return cipher;
        }
        private void button_XOR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_KEY_IN.Text))
            {
               
                MessageBox.Show("Ви забули ввести ключ?");
                textBox_KEY_IN.Focus();
               
            }
            
            string cipher = myCipher(textBox_P_IN, textBox_KEY_IN, textBox_C_IN); // зашифрування
            textBox_P_OUT.Text = textBox_C_IN.Text;
            textBox_KEY_OUT.Text = textBox_KEY_IN.Text;
            myCipher(textBox_P_OUT, textBox_KEY_OUT, textBox_C_OUT, cipher); // розшифрування
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            textBox_P_IN.Text = "";
            textBox_KEY_IN.Text = "";
            textBox_C_IN.Text = "";

            textBox_C_OUT.Text = "";
            textBox_KEY_OUT.Text = "";
            textBox_P_OUT.Text = "";
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox_P_OUT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
