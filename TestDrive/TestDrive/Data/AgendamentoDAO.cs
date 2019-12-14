using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using TestDrive.Models;

namespace TestDrive.Data
{
    class AgendamentoDAO
    {
        private SQLiteConnection conexao;

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<Agendamento>();

        }

        public void Salvar(Agendamento agendamento)
        {
            conexao.Insert(agendamento);
        }
    }
}
