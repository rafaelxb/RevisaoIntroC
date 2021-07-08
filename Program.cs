using System;

namespace RevisaoIntroC
{
    class Program
    {
        /*O objetivo deste projeto é desenvolver uma 
        aplicação console de cadastro, 
        listagem e calculo de média 
        geral dos alunos cadastrados*/
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
          
            string opcaoUsuario = ObterOpcUsuario();

            Console.WriteLine();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da Nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno ++;

                        break;
                    case "2":
                        foreach (var cadaAluno in alunos)
                        {
                            if (!string.IsNullOrEmpty(cadaAluno.Nome))
                            {
                                Console.WriteLine($"Aluno: {cadaAluno.Nome} - Nota: {cadaAluno.Nota}.");
                            }                            
                        }
                        break;
                    case "3":
                        decimal notaTot = 0;
                        int totalAlunos = 0;
                        decimal mediaGeral = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTot = notaTot + alunos[i].Nota;
                                totalAlunos ++;
                            }
                        }

                        mediaGeral = notaTot / totalAlunos;

                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        } 
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"A média geral dos alunos é {mediaGeral} e o conceito é {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcUsuario();
                Console.WriteLine();
            }
        }

        private static string ObterOpcUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();

            return opcaoUsuario;
        }
    }
}
