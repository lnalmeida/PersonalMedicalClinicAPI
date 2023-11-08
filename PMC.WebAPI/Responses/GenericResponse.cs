using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace PMC.WebAPI.Responses
{
    public class GenericResponse<T>
    {
        public GenericResponse() { }

        public GenericResponse(int statusCode, bool success, string? message, T? data)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Status da resposta
        /// </summary>
        /// <example>200</example>
        public int StatusCode { get; set; }
        /// <summary>
        /// Sucesso: true ou false
        /// </summary>
        /// <example>true</example>
        public bool Success { get; set; }
        /// <summary>
        /// Mensagem da resposta, caso haja
        /// </summary>
        /// <example>Mensagem de sucesso ou erro</example>
        public string? Message { get; set; }
        /// <summary>
        /// Corpo da resposta, caso haja
        /// </summary>
        public T? Data { get; set;}
    }
}
