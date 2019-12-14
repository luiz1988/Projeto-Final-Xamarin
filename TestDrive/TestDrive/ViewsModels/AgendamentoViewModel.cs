using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewsModels
{
    public class AgendamentoViewModel
    {
        public Agendamento Agendamento { get; set; }

        public  string Modelo
        {
            get { return this.Agendamento.Modelo;  }
            
            set { this.Agendamento.Modelo = value; }

        }

        public decimal Preco 
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
        }


        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }

            set
            {
                Agendamento.Nome = value;
            }

        }

        public string Fone
        {
            get
            {
                return Agendamento.Fone;
            }

            set
            {
                Agendamento.Fone = value;
            }

        }

        public string Email
        {
            get
            {
                return Agendamento.Email;
            }

            set
            {
                Agendamento.Email = value;
            }
        }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }

        //Chama no momento que abre a tela
        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento(veiculo.Nome, veiculo.Preco);

            AgendarCommand = new Command(() =>
            {
                if (this.SalvarAgendamento())
                {
                    MessagingCenter.Send<Agendamento>(this.Agendamento, "Agendamento");
                }
                else
                {
                    MessagingCenter.Subscribe<ArgumentException>(this, "Falha",
                        (msg) =>
                        {
                           //DisplayAlert("Agendamento", "Pedido não pôde ser realizado!", "ok");
                        });
                }
            });
        }

        //Persiste o agendamento do veiculo localmente
        public Boolean SalvarAgendamento()
        {
            using (var connection = DependencyService.Get<ISQLite>().getConnection())
            {
                try
                {
                    AgendamentoDAO dao = new AgendamentoDAO(connection);
                    dao.Salvar(new Agendamento(Nome, Fone, Email, Modelo, Preco));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public ICommand AgendarCommand { get; set; }
    }
}
