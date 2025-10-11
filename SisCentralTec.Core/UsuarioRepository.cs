using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class UsuarioRepository
{
    // Esta é a "ponte" para o banco de dados.
    // Vamos precisar ajustar essa linha para o seu ambiente.
    private readonly string _connectionString = "Server=DESKTOP-PIG820L\\SQLEXPRESS;Database=SisCentralTec;Integrated Security=True;";

    // Método para adicionar um novo usuário ao banco de dados
    public void AdicionarUsuario(Usuario usuario)
    {
        // O 'using' garante que a conexão com o banco é fechada ao final, mesmo se der erro.
        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            // 1. Abre a conexão
            conexao.Open();

            // 2. Define o comando SQL com parâmetros para evitar SQL Injection
            string sqlQuery = @"INSERT INTO Usuarios (Nome, Email, Senha, Perfil, Telefone, Setor, DataNascimento, CPF) 
                                VALUES (@Nome, @Email, @Senha, @Perfil, @Telefone, @Setor, @DataNascimento, @CPF)";

            // 3. Cria o objeto de comando
            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                // 4. Substitui os parâmetros pelos valores do objeto 'usuario'
                comando.Parameters.AddWithValue("@Nome", usuario.Nome);
                comando.Parameters.AddWithValue("@Email", usuario.Email);
                comando.Parameters.AddWithValue("@Senha", usuario.Senha); // Em um projeto real, a senha seria criptografada aqui
                comando.Parameters.AddWithValue("@Perfil", usuario.Perfil);
                comando.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                comando.Parameters.AddWithValue("@Setor", usuario.Setor);
                comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);
                comando.Parameters.AddWithValue("@CPF", usuario.CPF);

                // 5. Executa o comando
                comando.ExecuteNonQuery();
            }
        }
    }  
            // Método para autenticar um usuário
    public Usuario AutenticarUsuario(string email, string senha)
    {
        Usuario usuario = null; // Começa como nulo

        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            conexao.Open();

            // Query para buscar um usuário com o email e senha correspondentes
            string sqlQuery = "SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@Senha", senha);

                // Usamos SqlDataReader para ler os resultados da consulta
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    // Se o reader encontrou uma linha, significa que o login é válido
                    if (reader.Read())
                    {
                        // Cria o objeto Usuario com os dados do banco
                        usuario = new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Perfil = reader["Perfil"].ToString(),
                            Setor = reader["Setor"].ToString()
                            // Adicione outros campos se precisar deles após o login
                        };
                    }
                }
            }
        }

        return usuario; // Retorna o objeto usuario (se encontrado) ou null (se não encontrado)
    }
    // Método para listar todos os usuários
    public List<Usuario> ListarTodosUsuarios()
    {
        // Cria uma lista vazia para armazenar os usuários
        List<Usuario> listaDeUsuarios = new List<Usuario>();

        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            conexao.Open();

            string sqlQuery = "SELECT Id, Nome, Email, Perfil, Setor FROM Usuarios"; // Buscamos só os dados necessários para a lista

            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    // O loop 'while' continua enquanto houver linhas para ler
                    while (reader.Read())
                    {
                        // Cria um objeto Usuario para cada linha encontrada
                        Usuario usuario = new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Perfil = reader["Perfil"].ToString(),
                            Setor = reader["Setor"].ToString()
                        };

                        // Adiciona o usuário na lista
                        listaDeUsuarios.Add(usuario);
                    }
                }
            }
        }

        return listaDeUsuarios; // Retorna a lista completa
    }
}

