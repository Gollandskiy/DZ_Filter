using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DZ_Filter.Models
{
    public class LogActionFilter : Attribute,IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
            string logMessage = $"{DateTime.Now} - Controller: {controllerName}, Action: {actionName}";

            string filePath = @"D:\Visual Studio ШАГ\C#\DZ_Filter\log.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(logMessage);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
