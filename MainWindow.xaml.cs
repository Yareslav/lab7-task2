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
namespace Hme2
{
    public partial class MainWindow : Window
    {
        private Store store = new Store();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ResetPoroductData(object sender, RoutedEventArgs e)
        {
            string Name = ProductName.Text;
            string Store = ProductStore.Text;
            int Price;
            if (int.TryParse(ProductPrice.Text, out Price))
            {
                if (Name=="")
                {
                    MessageBox.Show("Name is empty");
                    return;
                }
                if (Store=="")
                {
                    MessageBox.Show("Store is empty");
                    return;
                }
                MessageBox.Show("Product was succesfully updated");
                store.Change(new Article(Name, Store, Price));
            }
            else MessageBox.Show("price is in wrong format");
        }
        private void SearchByIndex(object sender, RoutedEventArgs e)
        {
            int index;
            if (int.TryParse(IndexField.Text,out index))
            {
                var product= store.GetProductByIndex(index);
                if (product!=null)
                {
                    FillProductData(product);
                } else MessageBox.Show($"There is no product with id {index}");
            } else MessageBox.Show("Index is in wrong format");
        }
        private void SearchByName(object sender, RoutedEventArgs e)
        {
            var name = NameField.Text;
            var product = store.GetProductByName(name);
            if (name != "") {
                if (product!=null)
                {
                    FillProductData(product);
                } else MessageBox.Show($"There is no product with name {name}");
            }
            else MessageBox.Show("Enter the name of product");
        }
        private void FillProductData(Article product)
        {
            ProductPrice.Text = product.Price + "";
            ProductStore.Text = product.Store;
            ProductName.Text = product.Name;
        }
    }
    class Article
    {
        public string Name;
        public string Store;
        public int Price;
        public Article(string Name,string Store,int Price)
        {
            this.Name = Name;
            this.Store = Store;
            this.Price = Price;
        }
    }
    class Store
    {
        public int SelectedStoreId;
        public Article[] value=new Article[] {new Article("Banana","Monkey Shop",30),new Article("apple","Vanila meyvey",20),new Article("cheese","Rokfor",80)};
        public Article GetProductByName(string Name)
        {
            Article result=null;
            for (var i = 0; i <value.Length; i++)
            {
                if (Name.ToLower() == value[i].Name.ToLower())
                {
                    result = value[i];
                    this.SelectedStoreId = i;
                }
            }
            return result;
        }
        public Article GetProductByIndex(int ind)
        {
            bool contains = ind > value.Count() - 1;
            if (contains) return null;
            else
            {
                this.SelectedStoreId = ind;
                return value[ind];
            }
        }
        public void Change(Article product)
        {
            value[SelectedStoreId] = product;
        }
    }
}
