using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class ChamadoRepository
{
    // Usamos a mesma connection string
    private readonly string _connectionString = "Server=DESKTOP-PIG820L\\SQLEXPRESS;Database=SisCentralTec;Integrated Security=True;";

    // Método para adicionar (abrir) um novo chamado
    public void AbrirChamado(Chamado chamado)
    {
        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            conexao.Open();

            string sqlQuery = @"INSERT INTO Chamados (IdUsuario, Titulo, Descricao, Categoria, Prioridade, Status, DataAbertura) 
                                VALUES (@IdUsuario, @Titulo, @Descricao, @Categoria, @Prioridade, @Status, @DataAbertura)";

            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                comando.Parameters.AddWithValue("@IdUsuario", chamado.IdUsuario);
                comando.Parameters.AddWithValue("@Titulo", chamado.Titulo);
                comando.Parameters.AddWithValue("@Descricao", chamado.Descricao);
                comando.Parameters.AddWithValue("@Categoria", chamado.Categoria);
                comando.Parameters.AddWithValue("@Prioridade", chamado.Prioridade);
                comando.Parameters.AddWithValue("@Status", chamado.Status);
                comando.Parameters.AddWithValue("@DataAbertura", chamado.DataAbertura);

                comando.ExecuteNonQuery();
            }
        }
    }
    // Método para listar todos os chamados
    public List<Chamado> ListarTodosChamados()
    {
        List<Chamado> listaDeChamados = new List<Chamado>();

        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            conexao.Open();

            string sqlQuery = "SELECT Id, IdUsuario, Titulo, Categoria, Prioridade, Status, DataAbertura FROM Chamados ORDER BY DataAbertura DESC";

            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Chamado chamado = new Chamado
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Titulo = reader["Titulo"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Prioridade = reader["Prioridade"].ToString(),
                            Status = reader["Status"].ToString(),
                            DataAbertura = Convert.ToDateTime(reader["DataAbertura"])
                        };
                        listaDeChamados.Add(chamado);
                    }
                }
            }
        }
        return listaDeChamados;
    }
    // Método para atualizar o status de um chamado
    public void AtualizarStatusChamado(int idChamado, string novoStatus)
    {
        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            conexao.Open();

            // Comando SQL para atualizar o campo Status na tabela Chamados
            string sqlQuery = "UPDATE Chamados SET Status = @NovoStatus WHERE Id = @IdChamado";

            // Se o novo status for "Resolvido" ou "Encerrado", também atualizamos a DataEncerramento
            if (novoStatus == "Resolvido" || novoStatus == "Encerrado")
            {
                sqlQuery = "UPDATE Chamados SET Status = @NovoStatus, DataEncerramento = @DataEncerramento WHERE Id = @IdChamado";
            }

            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                comando.Parameters.AddWithValue("@NovoStatus", novoStatus);
                comando.Parameters.AddWithValue("@IdChamado", idChamado);

                if (novoStatus == "Resolvido" || novoStatus == "Encerrado")
                {
                    comando.Parameters.AddWithValue("@DataEncerramento", DateTime.Now);
                }

                comando.ExecuteNonQuery();
            }
        }
    }
}
