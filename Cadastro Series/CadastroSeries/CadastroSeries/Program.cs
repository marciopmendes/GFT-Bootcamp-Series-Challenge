using CadastroSeries;
using System;

namespace CadastroSeries
{
	class Program
	{
		static SerieRepositorio repositorio = new SerieRepositorio();

		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario != "0")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "6":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}
				
				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}
		private static string ObterOpcaoUsuario()
		{
            Console.WriteLine();
			Console.WriteLine("1- Listar series");
			Console.WriteLine("2 - Inserir Nova Serie");
			Console.WriteLine("3 - Atualizar Serie");
			Console.WriteLine("4 - Excluir Serie");
			Console.WriteLine("5 - Visualizar Serie");
			Console.WriteLine("6 - Limpar Tela");
			Console.WriteLine("0 - Sair do Programa");

			while (true)
            {
				Console.Write("Escolha sua opcao(numero entre 0 e 6):");
				string opcaoUsuario = Console.ReadLine();
				int x;
				Console.WriteLine();
				if (int.Parse(opcaoUsuario) >= 0 && int.Parse(opcaoUsuario) <= 6)
                {
					return opcaoUsuario;
				}
				else
                {
                    Console.WriteLine("Opcao Invalida\n");
                }
			}
		}

		private static void ListarSeries()
		{
            Console.WriteLine("Listar Series");
			var lista = repositorio.Listar();
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Serie Cadastrada\n");
				return;
			}
			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();
				if (!excluido)
				{
					Console.WriteLine($"#ID {serie.retornaId()}: - {serie.retornaTitulo()}\n");
				}
			}
		}

		private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova serie");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
			}
			Console.WriteLine("Digite o genero entre as opcoes acima");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite o titulo da serie");
			string entradaTitulo = Console.ReadLine();

			Console.WriteLine("Digite o ano de inicio da serie");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.WriteLine("Digite a descricao da serie");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
			repositorio.Insere(novaSerie);
		}

		private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i}-{Enum.GetName(typeof(Genero), i)}");
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
		private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            Console.WriteLine("Tem certeza que deseja excluir a serie? (S/N):");
            Console.WriteLine(repositorio.RetornaPorId(indiceSerie));
			var confirma = Console.ReadLine().ToUpper();

			if (confirma == "S")
			{
				repositorio.Exclui(indiceSerie);
                Console.WriteLine("Serie excluida");
			}
            else
            {
				Console.WriteLine("Operacao Cancelada");
            }
		}

		private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}
	}
}