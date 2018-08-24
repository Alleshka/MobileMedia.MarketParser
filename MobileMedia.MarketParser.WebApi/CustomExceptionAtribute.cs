using System;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http;

namespace MobileMedia.MarketParser.WebApi
{
    public class CustomExceptionAtribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext != null)
            {
                HttpResponseMessage response = null;
                String message = "";

                if(actionExecutedContext.Exception is NullReferenceException)
                {
                    message = "Не удалось найти приложение";
                    response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                }

                if (response == null)
                {
                    message = "Неизвестная ошибка";
                    response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
                }

                response.Content = new StringContent(message);
                throw new HttpResponseException(response);
            }
        }
    }
}