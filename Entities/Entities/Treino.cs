﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Treino
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public required string Titulos { get; set; }
        public required DateOnly Data { get; set; }
        public List<ExercicioFeito>? ExerciciosFeitos { get; set;}
    }
}
