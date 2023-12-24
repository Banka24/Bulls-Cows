using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BullsAndCows
{
    public partial class MainPage : ContentPage
    {
        private int _numberAI;
        public MainPage()
        {
            InitializeComponent();
            Random random = new Random();
            _numberAI = random.Next(1000, 9999);
        }

        //Проверка, находятся ли одинаковы числа на одном месте
        private int GetBulls(int numberUser)
        {
            int numberAI = _numberAI;
            int bulls = 0;
            for (int i = 0; i < 4; i++)
            {
                int lastUserNumber = numberUser % 10;
                int lastAINumber = numberAI % 10;
                if (lastUserNumber == lastAINumber)
                {
                    bulls++;
                }
                numberUser /= 10;
                numberAI /= 10;
            }
            return bulls;
        }

        //Проверка, есть ли цифра в числе
        private int GetCows(int numberUser)
        {
            int numberAI = _numberAI;
            int cows = 0;
            for (int i = 0; i < 4; i++)
            {
                int lastAINumber = numberAI % 10;
                for (int j = 0; j < 4; j++)
                {
                    int lastUserNumber = numberUser % 10;
                    if (lastUserNumber == lastAINumber)
                    {
                        cows++;
                    }
                    numberUser /= 10;
                }
                numberAI /= 10;
            }
            return cows;
        }

        private void CompliteButton_Clicked(object sender, EventArgs e)
        {
            int numberUser;

            if(!int.TryParse(NumberEntry.Text, out numberUser))
            {
                NumberEntry.Text = "Введите число";
                return;
            }
            if(numberUser < 1000 || numberUser > 9999)
            {
                NumberEntry.Text = "Введите 4-х значное число";
                return;
            }

            int bulls = GetBulls(numberUser);
            int cows = GetCows(numberUser);

            CowEntry.Text = $"{cows}";
            BullEntry.Text = $"{bulls}\nЧисло компьютера: {_numberAI}";
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            NumberEntry.Text = "";
        }
    }
}
