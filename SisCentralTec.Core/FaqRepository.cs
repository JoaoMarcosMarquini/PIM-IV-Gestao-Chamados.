using System;
using System.Collections.Generic;

public class FaqRepository
{
    // No futuro, isso poderia vir de um banco de dados ou de uma API de IA.
    // Por enquanto, retornamos uma lista fixa (hardcoded).
    public List<FaqItem> ListarPerguntasFrequentes()
    {
        var listaFaq = new List<FaqItem>
        {
            new FaqItem {
                Id = 1,
                Pergunta = "Minha impressora não está funcionando ou está offline. O que eu faço?",
                Resposta = "Primeiro, verifique se a impressora está ligada e conectada ao computador ou à rede. Tente reiniciá-la. Se o problema persistir, verifique se há papel e se os cartuchos de tinta/toner não estão vazios."
            },
            new FaqItem {
                Id = 2,
                Pergunta = "Estou recebendo um 'erro 500' ou não consigo acessar o sistema da folha de pagamento. Como proceder?",
                Resposta = "Este é um erro interno do servidor. Tente limpar o cache do seu navegador e acessar novamente. Se o erro continuar, informe ao setor de TI, pois pode ser uma instabilidade geral do sistema."
            },
            new FaqItem {
                Id = 3,
                Pergunta = "Meu computador está muito lento, especialmente ao iniciar. Tem conserto?",
                Resposta = "A lentidão pode ser causada por muitos programas iniciando com o Windows ou por falta de espaço em disco. Tente reiniciar o computador. Se a lentidão for constante, abra um chamado para a equipe de TI analisar."
            },
            new FaqItem {
                Id = 4,
                Pergunta = "Não consigo enviar e-mails com anexos grandes. Qual é o limite?",
                Resposta = "Nosso sistema de e-mail possui um limite de 25MB por mensagem. Se o seu arquivo for maior, utilize o serviço de nuvem (como Google Drive/OneDrive) e envie apenas o link para o arquivo."
            },
            new FaqItem {
                Id = 5,
                Pergunta = "Preciso de acesso a uma pasta na rede, mas ela diz 'Acesso Negado'. O que fazer?",
                Resposta = "O acesso a pastas da rede é controlado por permissões. Por favor, abra um chamado na categoria 'Acesso' especificando o caminho completo da pasta e a justificativa para o acesso."
            }
        };

        return listaFaq;
    }
}