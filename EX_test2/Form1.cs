using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EX_test2
{
    public partial class Form1 : Form
    {
        static int number =0;
        public Form1()
        {
            InitializeComponent();
            CountNamber();
            textBoxNumber.Enabled=false;
            dateTime.Enabled = false;
            comboBox1.SelectedIndex = 1;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //Кнопка отмены
        {
            if(MessageBox.Show("Вы хотите очистить все поля?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearDate();
                EnableOrDisableDate(true);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (CheckingTheCompletenessOfAllData())
            {
                if (CheckingForIncorrectCharactersInPayer())
                {
                    if (CheckingTheAmountForIncorrectCharacters())
                    {
                        if (MessageBox.Show("Вы хотите отправить данные?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            ShowData();
                            EnableOrDisableDate(false);
                            CountNamber();

                        }
                    }
                    else
                    {
                        MessageBox.Show("В поле Сумма введены неверные символы. Убедитесь что написали все правильно", "Ошибка");
                    }
                    
                }
                else
                {
                    MessageBox.Show("В поле Плательщик введены неверные символы. Убедитесь что написали все правильно", "Ошибка");
                }
                
            }
            else
            {
                MessageBox.Show("Некоторые поля не заполнены.","Ошибка");
            }
            
        }
        private void ClearDate()
        {
            dateTime.Value= DateTime.Now;
            comboBox1.SelectedIndex = 1;
            textBoxPayer.Clear();
        }
        private void ShowData()
        {
            MessageBox.Show("Платежное поручение принято к исполнению .\n\n" +
                              $"Number: {textBoxNumber.Text}\n" +
                              $"Время: {dateTime.Value.ToShortDateString()}\n"+
                              $"Плательщик: {textBoxPayer.Text}\n"+
                              $"Банк: {comboBox1.Text}\n"
                              ,"Ваши данные");
        }
        private void EnableOrDisableDate(bool enable)
        {
            //textBoxNamber.Enabled = enable;
            //dateTime.Enabled = enable;
            textBoxPayer.Enabled = enable;
        }
        private void CountNamber()
        {
            number++;
            string numberString = Convert.ToString(number);
            textBoxNumber.Text = numberString;
        }
        private bool CheckingTheCompletenessOfAllData()
        {
            return !string.IsNullOrWhiteSpace(textBoxPayer.Text);
        }
        private bool CheckingForIncorrectCharactersInPayer()
        {
            string pattern = @"^[\u0041-\u044B]*[-]?[\u0041-\u044B]*$";
            return Regex.IsMatch(textBoxPayer.Text, pattern);
        }
        private bool CheckingTheAmountForIncorrectCharacters()
        {
            string pattern = @"^[0-9]{9}$";
            return Regex.IsMatch(textBox8.Text, pattern);
        }
    }
}
