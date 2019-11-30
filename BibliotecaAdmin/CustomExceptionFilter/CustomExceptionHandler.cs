﻿using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BibliotecaAdmin.CustomExceptionFilter
{
    public class CustomExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                        ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                         ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                         : getErrorCode(context.Exception.GetType());
            string errorMessage = context.Exception.Message;
            string customErrorMessage = Mensajes.ERRORMSG;
            string stackTrace = context.Exception.StackTrace;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(
                new
                {
                    message = customErrorMessage,
                    isError = true,
                    errorCode = statusCode,
                }); 
            response.ContentLength = result.Length;
            response.WriteAsync(result);
        }

        /// <summary>  
        /// This method will return the status code based on the exception type.  
        /// </summary>  
        /// <param name="exceptionType"></param>  
        /// <returns>HttpStatusCode</returns>  
        private HttpStatusCode getErrorCode(Type exceptionType)
        {
            Exceptions tryParseResult;
            if (Enum.TryParse<Exceptions>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case Exceptions.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case Exceptions.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case Exceptions.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Exceptions.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case Exceptions.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case Exceptions.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case Exceptions.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case Exceptions.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case Exceptions.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case Exceptions.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case Exceptions.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case Exceptions.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case Exceptions.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Exceptions.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case Exceptions.IOException:
                        return HttpStatusCode.NotFound;

                    case Exceptions.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
