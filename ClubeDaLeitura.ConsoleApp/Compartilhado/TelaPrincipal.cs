﻿using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloMulta;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
namespace ControleMedicamentos.ConsoleApp.Compartilhado
{
    internal class TelaPrincipal : TelaBase
    {
        static TelaCaixa telaCaixa = new(new RepositorioCaixa(), "caixa");
        static TelaRevista telaRevista = new(new RepositorioRevista(), telaCaixa, "revista");
        static TelaAmigo telaAmigo = new(new RepositorioAmigo(), telaMulta, "amigo");
        static TelaMulta telaMulta = new(new RepositorioMulta(), telaAmigo, "multa");
        static TelaEmprestimo telaEmprestimo = new(new RepositorioEmprestimo(), telaAmigo, telaRevista, telaMulta, telaReserva, "empréstimo");
        static TelaReserva telaReserva = new(new RepositorioReserva(), telaAmigo, telaRevista, telaEmprestimo, "reserva");

        public void MenuPrincipal(ref bool sair)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("|               Clube do Livro                |");
            Console.WriteLine("-----------------------------------------------\n");

            Console.WriteLine("1 - Gerir amigos");
            Console.WriteLine("2 - Gerir revistas");
            Console.WriteLine("3 - Gerir caixas");
            Console.WriteLine("4 - Gerir empréstimos");
            Console.WriteLine("5 - Gerir reservas");
            Console.WriteLine("6 - Gerir multas");
            Console.WriteLine("S - Sair");

            string opcaoEscolhida = RecebeString("\nEscolha uma das opções: ");

            TelaBase tela = null;            
            switch (opcaoEscolhida)
            {
                case "1": tela = telaAmigo; break;
                case "2": tela = telaRevista; break;
                case "3": tela = telaCaixa; break;
                case "4": tela = telaEmprestimo; break;
                case "5": tela = telaReserva; break;
                case "6": tela = telaMulta; break;
                case "S": sair = true; break;
                default: OpcaoInvalida(); break;
            }
            tela?.ApresentarMenu(ref sair);
        }

        public override void VisualizarRegistros(bool exibirTitulo) => throw new NotImplementedException();
        protected override EntidadeBase ObterRegistro(int id) => throw new NotImplementedException();
    }
}
