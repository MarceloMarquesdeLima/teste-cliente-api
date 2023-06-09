﻿using System;
using System.ComponentModel.DataAnnotations;
using Opea.Domain.Models.Enum;

namespace Opea.Api.ViewModels
{
	public class ClienteViewModel
	{
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public int Porte { get; set; }
    }
}

