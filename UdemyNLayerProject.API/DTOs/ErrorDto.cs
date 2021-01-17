using System;
using System.Collections.Generic;

namespace UdemyNLayerProject.API.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        //hatalarınız birden fazla olabiir bu yüzden
        public List<String> Errors { get; set; }

        public int Status { get; set; }
    }
}
