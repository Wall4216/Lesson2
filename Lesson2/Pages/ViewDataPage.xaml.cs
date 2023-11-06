﻿using Lesson2.DataModels;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class ViewDataPage : Page
    {
        public ViewDataPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new UserEntities())
            {
                var dishes = context.Dishes.ToList();
                DishesDataGrid.ItemsSource = dishes; 
            }
        }
    }
}
