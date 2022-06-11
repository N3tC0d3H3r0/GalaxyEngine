using System;

namespace Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string entity, string name)
            : base($"Entity {entity} with name \"{name}\" already exists.") { }
    }
}
