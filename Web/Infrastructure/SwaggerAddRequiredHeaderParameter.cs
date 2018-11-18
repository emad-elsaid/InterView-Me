using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public class SwaggerAddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var param = new SwaggerParams();
            param.Name = "Authorization";
            param.In = "header";
            param.Description = "JWT Token";
            param.Required = false;
            param.Type = "string";
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
            operation.Parameters.Add(param);
        }

        
    }


}
