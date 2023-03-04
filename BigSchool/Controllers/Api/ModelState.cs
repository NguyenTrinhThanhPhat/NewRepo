using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BigSchool.Controllers.Api
{
    internal class ModelState
    {
        public object Errors { get; internal set; }

        public static implicit operator ModelState?(ModelStateEntry? v)
        {
            throw new NotImplementedException();
        }
    }
}