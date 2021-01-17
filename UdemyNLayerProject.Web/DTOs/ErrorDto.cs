using System;
using System.Collections.Generic;

namespace UdemyNLayerProject.Web.DTOs
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
