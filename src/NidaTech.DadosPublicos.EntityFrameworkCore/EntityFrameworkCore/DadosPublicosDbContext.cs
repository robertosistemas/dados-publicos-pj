using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NidaTech.DadosPublicos.Authorization.Roles;
using NidaTech.DadosPublicos.Authorization.Users;
using NidaTech.DadosPublicos.MultiTenancy;
using NidaTech.DadosPublicos.Modelos;
using System.Text;

namespace NidaTech.DadosPublicos.EntityFrameworkCore
{
    public class DadosPublicosDbContext : AbpZeroDbContext<Tenant, Role, User, DadosPublicosDbContext>
    {
        public virtual DbSet<AtividadeEconomicaModelo> AtividadesEconomicas { get; set; }
        public virtual DbSet<AtividadeEconomicaSecundariaModelo> AtividadesEconomicasSecundarias { get; set; }
        public virtual DbSet<ControleImportacaoModelo> ControlesImportacoes { get; set; }
        public virtual DbSet<DadoCadastralModelo> DadosCadastrais { get; set; }
        public virtual DbSet<LogicoModelo> Logicos { get; set; }
        public virtual DbSet<MatrizFilialModelo> MatrizesFiliais { get; set; }
        public virtual DbSet<MotivoSituacaoCadastralModelo> MotivosSituacoesCadastrais { get; set; }
        public virtual DbSet<MunicipioModelo> Municipios { get; set; }
        public virtual DbSet<NaturezaJuridicaModelo> NaturezasJuridicas { get; set; }
        public virtual DbSet<OpcaoSimplesModelo> OpcoesSimples { get; set; }
        public virtual DbSet<PaisModelo> Paises { get; set; }
        public virtual DbSet<PorteModelo> Portes { get; set; }
        public virtual DbSet<QualificacaoModelo> Qualificacoes { get; set; }
        public virtual DbSet<SituacaoCadastralModelo> SituacoesCadastrais { get; set; }
        public virtual DbSet<SocioModelo> Socios { get; set; }
        public virtual DbSet<TipoSocioModelo> TiposSocios { get; set; }
        public virtual DbSet<UnidadeFederacaoModelo> UnidadesFederacao { get; set; }

        static DadosPublicosDbContext()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public DadosPublicosDbContext(DbContextOptions<DadosPublicosDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AtividadeEconomicaModelo>(entity =>
            {
                entity.ToTable("AtividadeEconomica");

                entity.HasKey(e => e.Id)
                    .HasName("PK_AtividadeEconomica");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_AtividadeEconomica");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.CodigoClasse).HasMaxLength(7);

                entity.Property(e => e.CodigoDivisao).HasMaxLength(2);

                entity.Property(e => e.CodigoGrupo).HasMaxLength(4);

                entity.Property(e => e.CodigoSecao).HasMaxLength(1);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NomeClasse).HasMaxLength(100);

                entity.Property(e => e.NomeDivisao).HasMaxLength(100);

                entity.Property(e => e.NomeGrupo).HasMaxLength(100);

                entity.Property(e => e.NomeSecao).HasMaxLength(100);

                entity.Property(e => e.QuantidadeEmpresasAtivas);

                entity.Property(e => e.QuantidadeEmpresasInativas);
            });

            modelBuilder.Entity<AtividadeEconomicaSecundariaModelo>(entity =>
            {
                entity.ToTable("AtividadeEconomicaSecundaria");

                entity.HasOne<AtividadeEconomicaModelo>()
                    .WithMany()
                    .HasForeignKey(p => p.AtividadeEconomicaId)
                    .HasPrincipalKey(p => p.Id)
                    .HasConstraintName("FK_AtivEconSecu_AtivEcon");

                entity.HasOne<DadoCadastralModelo>()
                    .WithMany()
                    .HasForeignKey(p => p.Cnpj)
                    .HasPrincipalKey(p => p.Cnpj)
                    .HasConstraintName("FK_AtivEconSecu_DadoCadastral");

                entity.HasKey(e => e.Id)
                    .HasName("PK_AtividadeEconomicaSecundaria");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => new { e.Cnpj, e.AtividadeEconomicaId })
                    .HasName("UK_AtividadeEconomicaSecundaria");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14);

            });

            modelBuilder.Entity<ControleImportacaoModelo>(entity =>
            {
                entity.ToTable("ControleImportacao");

                entity.HasKey(e => e.Id)
                    .HasName("PK_ControleImportacao");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.NomeArquivo)
                    .HasName("UK_ControleImportacao");

                entity.Property(e => e.DataGravacao).HasColumnType("DATE");

                entity.Property(e => e.DataImportacao).HasColumnType("DATE");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.NumeroRemessa)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<DadoCadastralModelo>(entity =>
            {
                entity.ToTable("DadoCadastral");

                entity.HasOne<AtividadeEconomicaModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.AtividadeEconomicaId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_AtivEcon");

                entity.HasKey(e => e.Id)
                    .HasName("PK_DadoCadastral");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                //entity.HasIndex(e => e.Id)
                //    .IsUnique()
                //    .HasName("IX_DadoCadastral_Id_Desc");

                entity.HasAlternateKey(e => e.Cnpj)
                    .HasName("UK_DadoCadastral");

                entity.HasOne<MatrizFilialModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.MatrizFilialId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_MatrizFilial");

                entity.HasOne<MotivoSituacaoCadastralModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.MotivoSituacaoCadastralId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_MotiSitu");

                entity.HasOne<MunicipioModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.MunicipioId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_Municipio");

                entity.HasOne<NaturezaJuridicaModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.NaturezaJuridicaId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_NatuJuri");

                entity.HasOne<LogicoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.OpcaoMei)
                   .HasPrincipalKey(p => p.Codigo)
                   .HasConstraintName("FK_DadoCadastral_Logico");

                entity.HasOne<OpcaoSimplesModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.OpcaoSimplesId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_OpcaoSimples");

                entity.HasOne<PaisModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.PaisId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_Pais");

                entity.HasOne<PorteModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.PorteId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_Porte");

                entity.HasOne<QualificacaoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.QualificacaoResponsavelId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_QualResp");

                //entity.HasIndex(e => e.RazaoSocialNomeEmpresarial)
                //    .HasName("IX_DadoCadastral_RazaSociNome");

                entity.HasOne<SituacaoCadastralModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.SituacaoCadastralId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_SituCada");

                entity.HasOne<UnidadeFederacaoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.UnidadeFederacaoId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_DadoCadastral_UnidFede");

                entity.Property(e => e.Bairro).HasMaxLength(50);

                entity.Property(e => e.CapitalSocial).HasColumnType("DECIMAL(14, 2)");

                entity.Property(e => e.Cep).HasMaxLength(8);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Complemento).HasMaxLength(156);

                entity.Property(e => e.CorreioEletronico).HasMaxLength(115);

                entity.Property(e => e.DataExclusaoSimples).HasColumnType("DATE");

                entity.Property(e => e.DataInicioAtividade).HasColumnType("DATE");

                entity.Property(e => e.DataOpcaoSimples).HasColumnType("DATE");

                entity.Property(e => e.DataSituacaoCadastral).HasColumnType("DATE");

                entity.Property(e => e.DataSituacaoEspecial).HasColumnType("DATE");

                entity.Property(e => e.Ddd1).HasMaxLength(4);

                entity.Property(e => e.Ddd2).HasMaxLength(4);

                entity.Property(e => e.DddFax).HasMaxLength(4);

                entity.Property(e => e.Fax).HasMaxLength(9);

                entity.Property(e => e.Logradouro).HasMaxLength(60);

                entity.Property(e => e.NomeCidadeExterior).HasMaxLength(55);

                entity.Property(e => e.NomeFantasia).HasMaxLength(55);

                entity.Property(e => e.Numero).HasMaxLength(6);

                entity.Property(e => e.OpcaoMei).HasMaxLength(1);

                entity.Property(e => e.RazaoSocialNomeEmpresarial)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.SituacaoEspecial).HasMaxLength(23);

                entity.Property(e => e.Telefone1).HasMaxLength(9);

                entity.Property(e => e.Telefone2).HasMaxLength(9);

                entity.Property(e => e.TipoLogradouro).HasMaxLength(20);
            });

            modelBuilder.Entity<LogicoModelo>(entity =>
            {
                entity.ToTable("Logico");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Logico");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_Logico");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<MatrizFilialModelo>(entity =>
            {
                entity.ToTable("MatrizFilial");

                entity.HasKey(e => e.Id)
                    .HasName("PK_MatrizFilial");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_MatrizFilial");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<MotivoSituacaoCadastralModelo>(entity =>
            {
                entity.ToTable("MotivoSituacaoCadastral");

                entity.HasKey(e => e.Id)
                    .HasName("PK_MotivoSituacaoCadastral");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_MotivoSituacaoCadastral");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MunicipioModelo>(entity =>
            {
                entity.ToTable("Municipio");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Municipio");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_Municipio");

                entity.HasOne<UnidadeFederacaoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.UnidadeFederacaoId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_Municipio_UnidadeFederacaoId");

                entity.Property(e => e.Cnpj).HasMaxLength(14);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Uf).HasMaxLength(2);

                entity.Property(e => e.QuantidadeEmpresasAtivas);

                entity.Property(e => e.QuantidadeEmpresasInativas);
            });

            modelBuilder.Entity<NaturezaJuridicaModelo>(entity =>
            {
                entity.ToTable("NaturezaJuridica");

                entity.HasKey(e => e.Id)
                    .HasName("PK_NaturezaJuridica");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_NaturezaJuridica");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OpcaoSimplesModelo>(entity =>
            {
                entity.ToTable("OpcaoSimples");

                entity.HasKey(e => e.Id)
                    .HasName("PK_OpcaoSimples");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_OpcaoSimples");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<PaisModelo>(entity =>
            {
                entity.ToTable("Pais");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Pais");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_Pais");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.QuantidadeEmpresasAtivas);

                entity.Property(e => e.QuantidadeEmpresasInativas);
            });

            modelBuilder.Entity<PorteModelo>(entity =>
            {
                entity.ToTable("Porte");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Porte");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_Porte");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<QualificacaoModelo>(entity =>
            {
                entity.ToTable("Qualificacao");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Qualificacao");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_Qualificacao");

                entity.Property(e => e.ColetadoAtualmente)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne<LogicoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.ColetadoAtualmente)
                   .HasPrincipalKey(p => p.Codigo)
                   .HasConstraintName("FK_Qualificacao_Logico");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<SituacaoCadastralModelo>(entity =>
            {
                entity.ToTable("SituacaoCadastral");

                entity.HasKey(e => e.Id)
                    .HasName("PK_SituacaoCadastral");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_SituacaoCadastral");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(8);
            });

            modelBuilder.Entity<SocioModelo>(entity =>
            {
                entity.ToTable("Socio");

                entity.HasOne<DadoCadastralModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.Cnpj)
                   .HasPrincipalKey(p => p.Cnpj)
                   .HasConstraintName("FK_Socio_DadoCadastral");

                entity.HasKey(e => e.Id)
                    .HasName("PK_Socio");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne<PaisModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.PaisId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_Socio_Pais");

                entity.HasOne<QualificacaoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.QualificacaoRepresentanteId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_Socio_QualificacaoRepr");

                entity.HasOne<QualificacaoModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.QualificacaoSocioId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_Socio_QualificacaoSocio");

                entity.HasOne<TipoSocioModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.TipoSocioId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_Socio_TipoSocio");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.CpfCnpj).HasMaxLength(14);

                entity.Property(e => e.CpfRepresentanteLegal).HasMaxLength(11);

                entity.Property(e => e.DataEntradaSociedade).HasColumnType("DATE");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.NomeRepresentanteLegal).HasMaxLength(60);

                entity.Property(e => e.PercentualCapitalSocial).HasColumnType("DECIMAL(14, 2)");
            });

            modelBuilder.Entity<TipoSocioModelo>(entity =>
            {
                entity.ToTable("TipoSocio");

                entity.HasKey(e => e.Id)
                    .HasName("PK_TipoSocio");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_TipoSocio");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<UnidadeFederacaoModelo>(entity =>
            {
                entity.ToTable("UnidadeFederacao");

                entity.HasKey(e => e.Id)
                    .HasName("PK_UnidadeFederacao");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasAlternateKey(e => e.Codigo)
                    .HasName("UK_UnidadeFederacao");

                entity.HasOne<PaisModelo>()
                   .WithMany()
                   .HasForeignKey(p => p.PaisId)
                   .HasPrincipalKey(p => p.Id)
                   .HasConstraintName("FK_UnidadeFederacao_Pais");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QuantidadeEmpresasAtivas);

                entity.Property(e => e.QuantidadeEmpresasInativas);

                entity.Property(e => e.Mostrar);
            });

        }

    }
}
