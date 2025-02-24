using AutoMapper;
using Entities.Dtos.Input.Exercicio;
using Entities.Dtos.Input.ExercicioFeito;
using Entities.Dtos.Input.Serie;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
using Entities.Dtos.Output.Exercicio;
using Entities.Dtos.Output.ExercicioFeito;
using Entities.Dtos.Output.Treino;
using Entities.Dtos.Output.VariacaoExercicio;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioEhCredenciaisDto, Usuario>();

            CreateMap<TreinoCriarDto, Treino>();
            CreateMap<TreinoEditarDto, Treino>();

            CreateMap<Treino, TreinoDetalhadoDto>();

            CreateMap<Exercicio, ExercicioDetalhadoDto>();

            CreateMap<ExercicioCriarDto, Exercicio>();

            CreateMap<ExercicioEditarDto, Exercicio>();

            CreateMap<VariacaoExercicio, VariacaoExercicioSimplificadoDto>();

            CreateMap<SerieEditarDto, Serie>();
            CreateMap<SerieCriarDto, Serie>();
        }
    }
}
