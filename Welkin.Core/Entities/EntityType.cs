using System;

namespace Avanzar.Welkin.Core.Entities
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =true, Inherited =true)]
    public class EntityType : System.Attribute
    {
        private string[] type;

        public string[] ResourceType { get { return type; } }

        public EntityType(string[] type)
        {
            this.type = type;
           
        }
    }
}
