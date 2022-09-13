using hotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace hotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContatacaoHospedagem : ContentPage
    {

        App PropriedadesApp;

        public ContatacaoHospedagem()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App) Application.Current;

            lbl_usuario.Text = App.Current.Properties["usuario_logado"].ToString();

            pck_suite.ItemsSource = PropriedadesApp.lista_suites;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddDays(1).AddMonths(6);
        }

         private void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new NavigationPage(new HospedagemCalculada()
                {

                    BindingContext = new Hospedagem()
                    {
                        Qntadulto = Convert.ToInt32(lbl_qnt_adultos.Text),
                        QntCriancas = Convert.ToInt32(lbl_qnt_criancas.Text),
                        QuartoEscolhido = (Suite)pck_suite.SelectedItem,
                        DataCheckIn = dtpck_checkin.Date,
                        DataCheckOut = dtpck_checkout.Date
                    }

                });
            }
            catch (Exception ex)
            {
                DisplayAlert("ops", ex.Message, "Ok");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool confime = await DisplayAlert("tem certeza?", "desconectar sua conta?", "sim", "não");

            if (confime)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }

        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }

}