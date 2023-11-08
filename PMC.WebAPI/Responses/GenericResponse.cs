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

        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set;}
    }
}
