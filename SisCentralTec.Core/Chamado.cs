using System;

public class Chamado
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public string Titulo { get; set; }

    public string Descricao { get; set; }

    public string Categoria { get; set; }

    public string Prioridade { get; set; }

    public string Status { get; set; }

    public DateTime DataAbertura { get; set; }

    // Usamos 'DateTime?' (com '?') porque a DataEncerramento pode ser nula
    // (um chamado aberto ainda não tem data de encerramento).
    public DateTime? DataEncerramento { get; set; }
}