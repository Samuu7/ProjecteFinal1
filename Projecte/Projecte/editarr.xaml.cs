using Projecte.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Projecte.Entity;
using Projecte;


namespace Projecte
{
    /// <summary>
    /// Lógica de interacción para editarr.xaml
    /// </summary>
    public partial class editarr : Window
    {
        Tasca edit;
        
        public editarr(MainWindow mw, Tasca editar)
        {
            InitializeComponent();
            edit = editar;
            this.DataContext = editar;

            if (editar != null)
            {
                //si estic editant la tasca carregaré les dades de tasca als camps
                txt_name.Text = editar.Name;
                txt_id.Text = editar.ID.ToString();
                txt_descripció.Text = editar.Descripcio;
                txt_data.SelectedDate = editar.Data;
                txt_data_1.SelectedDate = editar.Data1;
                //  combobox.SelectedItem = edit.

            }

            combobox.ItemsSource = ResponsableService.GetAll();
           

        }

        public void TextBox_txt_id(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_id;
        }
        public void TextBox_txt_descripció(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_descripció;
        }
        public void TextBox_txt_responsable(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_responsable;
        }
        public void TextBox_txt_data(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_txt_data;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TascaService userService = new TascaService();
                userService.Update(edit, edit.Estat);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}