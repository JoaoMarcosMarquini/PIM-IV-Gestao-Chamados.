using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        ChamadoRepository repository = new ChamadoRepository();

        Console.WriteLine("--- Teste de Relatório: Chamados por Categoria ---");

        // Chama o novo método de relatório por categoria
        Dictionary<string, int> contagemPorCategoria = repository.GetContagemChamadosPorCategoria();

        if (contagemPorCategoria.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Total de chamados por categoria encontrado:");
            Console.ResetColor();

            foreach (var item in contagemPorCategoria)
            {
                Console.WriteLine($"Categoria: {item.Key}, Total: {item.Value}");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nenhum chamado encontrado para o relatório.");
            Console.ResetColor();
        }

        Console.ReadLine();
    }
}