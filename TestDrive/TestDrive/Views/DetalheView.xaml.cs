using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 5000;

        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", FREIO_ABS);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", AR_CONDICIONADO);
            }
        }

        public string TextoArMP3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", MP3_PLAYER);
            }
        }

        bool temFreioABS;
        public bool TemFreioABS
        {
            get

            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;

                if (temFreioABS)
                    DisplayAlert("Freio ABS", "Ligado!", "Ok");
                else
                {
                    DisplayAlert("Freio ABS", "Desligado!", "Ok");
                }
            }
        }


        public DetalheView(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            InitializeComponent();
            this.BindingContext = this;
        }

        private void botaoProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}