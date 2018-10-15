using System;
using XboxGamesUI.ServiceLayer.Dtos;

namespace XboxGamesUI.ServiceLayer.REST
{
    public class XboxGamesServiceException : ApplicationException
    {
        public ExceptionResponseDTO ExceptionResponse { get; set; }

        public XboxGamesServiceException(): base()
        {
        }

        public XboxGamesServiceException(string message)
            : base(message)
        {
        }

        public XboxGamesServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public XboxGamesServiceException(string message, ExceptionResponseDTO exceptionResponse) 
            : base(message)
        {
            ExceptionResponse = exceptionResponse;
        }

        public XboxGamesServiceException(string message, ExceptionResponseDTO exceptionResponse, Exception innerException)
            : base(message, innerException)
        {
            ExceptionResponse = exceptionResponse;
        }
    }
}
