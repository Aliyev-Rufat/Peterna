﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel.Slider
{
    public class CreateSliderVm
    {
        [StringLength(25, ErrorMessage = "Uzlug 25 i kece bilmez")]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public IFormFile ImgFile { get; set; }

    }
}
