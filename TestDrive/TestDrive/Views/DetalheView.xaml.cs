using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(Valortotal));
            }
        }

        bool temArCondicionado;
        public bool TemArCondicionado
        {
            get

            {
                return temArCondicionado;
            }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Valortotal));
            }
        }

        bool temMP3Player;
        private Veiculo veiculo;

        public bool TemMP3Player
        {
            get

            {
                return temMP3Player;
            }
            set
            {
                temMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Valortotal));
            }
        }

        public string Valortotal { get {
                return string.Format("Valor Total: R$ {0}", Veiculo.preco
                    + (TemFreioABS ? FREIO_ABS : 0)
                    + (TemArCondicionado ? AR_CONDICIONADO : 0)
                    + (TemMP3Player ? MP3_PLAYER : 0));
            }
        }


        public DetalheView(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            InitializeComponent();
            this.BindingContext = this;
        }

        public DetalheView(Veiculo veiculo)
        {
            this.veiculo = veiculo;
        }

        private void botaoProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}