﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Экзамен
{
    /// <summary>
    /// Логика взаимодействия для RandomCode.xaml
    /// </summary>
    public partial class RandomCode : Window
    {
        public static int RC { get; set; }
        public RandomCode()
        {
            InitializeComponent();

            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Start();

            Random ran = new Random();
            RC = ran.Next(10000000, 99999999);
            RanCode.Text = RC.ToString();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            RC = 1111111;
            Close();
        }
    }
}
