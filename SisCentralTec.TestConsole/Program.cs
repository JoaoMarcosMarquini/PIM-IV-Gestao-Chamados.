using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iniciando teste de cadastro de usuário...");

        // 1. Cria um objeto Usuario com dados de teste
        Usuario novoUsuario = new Usuario
        {
            Nome = "João Marcos",
            Email = "joao.teste@empresa.com",
            Senha = "senha123",
            Perfil = "Admin",
            Telefone = "17999998888",
            Setor = "TI",
            DataNascimento = new DateTime(1995, 10, 20),
            CPF = "123.456.789-00"
        };

        // 2. Cria uma instância do nosso repositório
        UsuarioRepository repository = new UsuarioRepository();

        try
        {
            // 3. Chama o método para adicionar o usuário
            repository.AdicionarUsuario(novoUsuario);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário adicionado com sucesso!");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Se der algum erro, ele será exibido aqui
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            Console.ResetColor();
        }
    }
}