using AutoMapper;
using Entities.Dtos.Input.ExercicioFeito;
using Entities.Dtos.Input.Treino;
using Entities.Dtos.Input.Usuario;
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

            CreateMap<ExercicioFeitoCriarDto, ExercicioFeito>();
            CreateMap<ExercicioFeitoEditarDto, ExercicioFeito>();

            CreateMap<TreinoCriarDto, Treino>();
            CreateMap<TreinoEditarDto, Treino>();
        }
    }
}
