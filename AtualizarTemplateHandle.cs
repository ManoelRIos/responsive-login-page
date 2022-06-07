using cfc_sva.Application.Common.Interfaces;
using cfc_sva.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cfc_sva.Application.Templates;
 


public class AtualizarTemplateHandler : IRequestHandler<AtualizarTemplateRequest, int>
{

    private readonly IApplicationDbContext _context;

    public AtualizarTemplateHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AtualizarTemplateRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Template> query = _context.Templates;
        query = query.AsNoTracking().Where(template => template.Id == request.Id);
        var entity = await query.FirstOrDefaultAsync();


        entity.Nome = request.Nome;
        entity.Descricao = request.Descricao;
        entity.TextoTemplate = request.TextoTemplate;
        entity.RequerInteracaoDestinatario = request.RequerInteracaoDestinatario;




/*         var entity = new Template
        {
            Id = request.Id,
            Nome = request.Nome,
            Descricao = request.Descricao,
            TextoTemplate = request.TextoTemplate,
            RequerInteracaoDestinatario = request.RequerInteracaoDestinatario,

            TipoComunicacao = _context.TipoComunicacoes.First(x => x.Id == request.IdTipoComunicacao),
            Status = _context.Status.First(x => x.Id == request.IdStatus),
            TipoInteracaoDestinatario  = _context.TipoInteracoesDestinatario.First(x => x.Id == request.IdTipoInteracaoDestinatario),
            Tags = _context.Tags.Where(p => request.Tags != null && request.Tags.Contains(p.Id)).ToList(), 

            DataCriacao =   DateTime.Now,
            UsuarioCriacao = "Francisco",

            DataUltimaModificacao = DateTime.Now,            
            UsuarioUltimaModificacao = "Francisco"

        }; */

        _context.Templates.Add(entity);
        var result = await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
