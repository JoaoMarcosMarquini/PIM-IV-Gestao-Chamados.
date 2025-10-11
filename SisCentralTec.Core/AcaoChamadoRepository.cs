using System;
using System.Data.SqlClient;

public class AcaoChamadoRepository
{
    // A mesma connection string
    private readonly string _connectionString = "Server=DESKTOP-PIG820L\\SQLEXPRESS;Database=SisCentralTec;Integrated Security=True;";

    // Método para registrar uma nova ação em um chamado existente
    public void RegistrarAcao(AcaoChamado acao)
    {
        using (SqlConnection conexao = new SqlConnection(_connectionString))
        {
            conexao.Open();

            string sqlQuery = @"INSERT INTO AcoesChamado (IdChamado, IdTecnico, DescricaoAcao, DataAcao) 
                                VALUES (@IdChamado, @IdTecnico, @DescricaoAcao, @DataAcao)";

            using (SqlCommand comando = new SqlCommand(sqlQuery, conexao))
            {
                comando.Parameters.AddWithValue("@IdChamado", acao.IdChamado);
                comando.Parameters.AddWithValue("@IdTecnico", acao.IdTecnico);
                comando.Parameters.AddWithValue("@DescricaoAcao", acao.DescricaoAcao);
                comando.Parameters.AddWithValue("@DataAcao", acao.DataAcao);

                comando.ExecuteNonQuery();
            }
        }
    }
}