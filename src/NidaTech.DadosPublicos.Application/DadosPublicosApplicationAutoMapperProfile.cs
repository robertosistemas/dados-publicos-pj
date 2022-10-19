using AutoMapper;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos
{
    public class DadosPublicosApplicationAutoMapperProfile : Profile
    {
        public DadosPublicosApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<AtividadeEconomicaModelo, AtividadeEconomica>().ReverseMap();
            CreateMap<AtividadeEconomicaModelo, AtividadeEconomicaCriar>().ReverseMap();
            CreateMap<AtividadeEconomicaModelo, AtividadeEconomicaAtualizar>().ReverseMap();

            CreateMap<AtividadeEconomicaSecundariaModelo, AtividadeEconomicaSecundaria>().ReverseMap();
            CreateMap<AtividadeEconomicaSecundariaModelo, AtividadeEconomicaSecundariaCriar>().ReverseMap();
            CreateMap<AtividadeEconomicaSecundariaModelo, AtividadeEconomicaSecundariaAtualizar>().ReverseMap();

            CreateMap<DadoCadastralModelo, DadoCadastral>().ReverseMap();
            CreateMap<DadoCadastralModelo, DadoCadastralCriar>().ReverseMap();
            CreateMap<DadoCadastralModelo, DadoCadastralAtualizar>().ReverseMap();

            CreateMap<ControleImportacaoModelo, ControleImportacao>().ReverseMap();
            CreateMap<ControleImportacaoModelo, ControleImportacaoCriar>().ReverseMap();
            CreateMap<ControleImportacaoModelo, ControleImportacaoAtualizar>().ReverseMap();

            CreateMap<LogicoModelo, Logico>().ReverseMap();
            CreateMap<LogicoModelo, LogicoCriar>().ReverseMap();
            CreateMap<LogicoModelo, LogicoAtualizar>().ReverseMap();

            CreateMap<MatrizFilialModelo, MatrizFilial>().ReverseMap();
            CreateMap<MatrizFilialModelo, MatrizFilialCriar>().ReverseMap();
            CreateMap<MatrizFilialModelo, MatrizFilialAtualizar>().ReverseMap();

            CreateMap<MotivoSituacaoCadastralModelo, MotivoSituacaoCadastral>().ReverseMap();
            CreateMap<MotivoSituacaoCadastralModelo, MotivoSituacaoCadastralCriar>().ReverseMap();
            CreateMap<MotivoSituacaoCadastralModelo, MotivoSituacaoCadastralAtualizar>().ReverseMap();

            CreateMap<MunicipioModelo, Municipio>().ReverseMap();
            CreateMap<MunicipioModelo, MunicipioCriar>().ReverseMap();
            CreateMap<MunicipioModelo, MunicipioAtualizar>().ReverseMap();

            CreateMap<NaturezaJuridicaModelo, NaturezaJuridica>().ReverseMap();
            CreateMap<NaturezaJuridicaModelo, NaturezaJuridicaCriar>().ReverseMap();
            CreateMap<NaturezaJuridicaModelo, NaturezaJuridicaAtualizar>().ReverseMap();

            CreateMap<OpcaoSimplesModelo, OpcaoSimples>().ReverseMap();
            CreateMap<OpcaoSimplesModelo, OpcaoSimplesCriar>().ReverseMap();
            CreateMap<OpcaoSimplesModelo, OpcaoSimplesAtualizar>().ReverseMap();

            CreateMap<PaisModelo, Pais>().ReverseMap();
            CreateMap<PaisModelo, PaisCriar>().ReverseMap();
            CreateMap<PaisModelo, PaisAtualizar>().ReverseMap();

            CreateMap<PorteModelo, Porte>().ReverseMap();
            CreateMap<PorteModelo, PorteCriar>().ReverseMap();
            CreateMap<PorteModelo, PorteAtualizar>().ReverseMap();

            CreateMap<QualificacaoModelo, Qualificacao>().ReverseMap();
            CreateMap<QualificacaoModelo, QualificacaoCriar>().ReverseMap();
            CreateMap<QualificacaoModelo, QualificacaoAtualizar>().ReverseMap();

            CreateMap<SituacaoCadastralModelo, SituacaoCadastral>().ReverseMap();
            CreateMap<SituacaoCadastralModelo, SituacaoCadastralCriar>().ReverseMap();
            CreateMap<SituacaoCadastralModelo, SituacaoCadastralAtualizar>().ReverseMap();

            CreateMap<SocioModelo, Socio>().ReverseMap();
            CreateMap<SocioModelo, SocioCriar>().ReverseMap();
            CreateMap<SocioModelo, SocioAtualizar>().ReverseMap();

            CreateMap<TipoSocioModelo, TipoSocio>().ReverseMap();
            CreateMap<TipoSocioModelo, TipoSocioCriar>().ReverseMap();
            CreateMap<TipoSocioModelo, TipoSocioAtualizar>().ReverseMap();

            CreateMap<UnidadeFederacaoModelo, UnidadeFederacao>().ReverseMap();
            CreateMap<UnidadeFederacaoModelo, UnidadeFederacaoCriar>().ReverseMap();
            CreateMap<UnidadeFederacaoModelo, UnidadeFederacaoAtualizar>().ReverseMap();
        }
    }
}
