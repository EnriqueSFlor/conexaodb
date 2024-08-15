﻿using ScreenSound.Banco;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuMostrarPorAno : Menu
    {
        public override void Executar(DAL<Artista> artistaDAL)
        {
            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Exibir musicas por ano de lançamento");
            Console.Write("Digite o ano das músicas: ");
            string anoEscolhido = Console.ReadLine()!;
            var musicaDal = new DAL<Musica>(new ScreenSoundContext());
            var listaAnoLancamento = musicaDal.ListarPor(a => a.AnoLancamento == Convert.ToInt32(anoEscolhido));

            if (listaAnoLancamento.Any())
            {
                Console.WriteLine($"\nMusicas do Ano {anoEscolhido}:");
                foreach (var musica in listaAnoLancamento)
                {
                    musica.ExibirFichaTecnica();
                }
                Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO ano {anoEscolhido} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
