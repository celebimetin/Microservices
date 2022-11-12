using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessFul { get; private set; }
        public List<string> Errors { get; private set; }

        //Static Factory Method
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessFul = true };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessFul = true };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessFul = false, Errors = errors };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode, IsSuccessFul = false, Errors = new List<string>() { error } };
        }
    }
}