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
using WSR5.Database;

namespace WSR5.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        public void UpdateProducts()
        {
            try
            {


                var products = ClothesEntitys.GetEntitys().Products.ToList();

                //Сортировка
                if (SortComboBox.SelectedIndex == 0)
                    products = products.OrderBy(x => x.ProductCost).ToList();
                else
                    products = products.OrderByDescending(x => x.ProductCost).ToList();


                //Фильтрация
                switch (FiltrComboBox.SelectedIndex)
                {
                    case 0:
                        products = products.Where(x => x.ProductManufacturer != null).ToList();
                        break;
                    case 1:
                        products = products.Where(x => x.ProductManufacturer == "БТК Текстиль").ToList();
                        break;
                    case 2:
                        products = products.Where(x => x.ProductManufacturer == "Империя ткани").ToList();
                        break;
                    case 3:
                        products = products.Where(x => x.ProductManufacturer == "Комильфо").ToList();
                        break;
                    case 4:
                        products = products.Where(x => x.ProductManufacturer == "Май Фабрик").ToList();
                        break;
                }

                //Поиск

                products = (from a in products
                            where a.ProductName.ToLower().Contains(SearchTextBox.Text.ToLower())
                            || a.ProductManufacturer.ToLower().Contains(SearchTextBox.Text.ToLower())
                            || a.ProductSuplier.ToLower().Contains(SearchTextBox.Text.ToLower())
                            || a.ProductUnit.ToLower().Contains(SearchTextBox.Text.ToLower())
                            || a.ProductCategory.ToLower().Contains(SearchTextBox.Text.ToLower())
                            || a.ProductArticleNumber.ToLower().Contains(SearchTextBox.Text.ToLower())
                            || a.ProductDescription.ToLower().Contains(SearchTextBox.Text.ToLower())
                            select a).ToList();


                ProductsListView.ItemsSource = products;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void FiltrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }
    }
}
