﻿using System.ComponentModel.DataAnnotations;

namespace Kahla.SDK.Models.ApiAddressModels
{
    public class CompleteRequestAddressModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool Accept { get; set; }
    }
}
