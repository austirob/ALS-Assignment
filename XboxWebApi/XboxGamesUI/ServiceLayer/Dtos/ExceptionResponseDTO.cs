using System;

namespace XboxGamesUI.ServiceLayer.Dtos
{
    public class ExceptionResponseDTO
    {
        public String Message { get; set; }
        public String Stacktrace { get; set; }
        public Int32 StatusCode { get; set; }
    }
}
