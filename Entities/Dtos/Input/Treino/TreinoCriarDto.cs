﻿using Entities.Dtos.Input.ExercicioFeito;
using Entities.Dtos.Input.Serie;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Input.Treino
{
    public class TreinoCriarDto
    {
        public int UsuarioId { get; set; }
        public required string Titulo { get; set; }
        public required DateOnly Data { get; set; }
        public List<SerieCriarDto>? Series { get; set; }
    }
}
