using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RutasNZ_API.CustomActionFilters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /*  Para no  tener que agregar un  
           if (!ModelState.IsValid)
           {
               return BadRequest(ModelState);
           }
        en todos los metodos
       */
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            { 
        
                context.Result = new BadRequestResult();
            }
        }

       

    }
}
