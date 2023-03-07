using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThreadWPF
{

    public partial class MainWindow : Window
    {
        int[] num = new int[10000];
        int min, max;
        double m = 0;
        public MainWindow()
        {
            InitializeComponent();

            Thread myThread1 = new Thread(Print);
            myThread1.Start();
            Random random = new Random();
            Thread myThread3 = new Thread(Element);
            myThread3.Start();
            Thread myThread4 = new Thread(MinMax);
            myThread4.Start();
            Thread myThread5 = new Thread(Average);
            myThread5.Start();
            Thread myThread6 = new Thread(WriteAsync);
            myThread6.Start();

            void Print()
            {
                for (int i = 0; i <= 50; i++)
                {
                    Box1.Text+= Convert.ToString($"{i} ");
                }
            }
            void Element()
            {
                for (int i = 0; i < num.Length; i++)
                {
                    num[i] = random.Next(100);
                    Box1.Text += Convert.ToString($"{num[i]} ");
                }
            }
            void MinMax()
            {
                min = num[0];
                max = num[0];
                for (int i = 0; i < num.Length; i++)
                {
                    if (max < num[i]) max = num[i];
                    if (min > num[i]) min = num[i];
                }
                Box1.Text += Convert.ToString($"Max={max} \nMin={min}");
            }
            void Average()
            {


                for (int i = 0; i < num.Length; i++)
                {
                    m = m + num[i];
                }
                Box1.Text += Convert.ToString($"Average={m / 10000}");
            }
            async void WriteAsync()
            {
                string path = "note.txt";
                string text = $"Average={m / 10000} Max={max} \nMin={min}";

                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    await writer.WriteLineAsync(text);
                }
            }
        }
    }
}
