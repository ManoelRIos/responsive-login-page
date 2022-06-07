using MediatR;
using cfc_sva.Domain.Entities;



namespace cfc_sva.Application.Templates;
public class AtualizarTemplateRequest : IRequest<int>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public string TextoTemplate { get; set; }
    
    public int IdTipoComunicacao { get; set; }
    public int IdStatus { get; set; }
    public bool RequerInteracaoDestinatario { get; set; }
    public int IdTipoInteracaoDestinatario { get; set; }
    public List<int> Tags { get; set; }


}