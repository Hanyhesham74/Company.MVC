﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Demo.BusinessLogic.DTOS
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Code Is Required")]
        public string Code { get; set; }= string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateOnly DateOfCreation { get; set; }
    }
}
