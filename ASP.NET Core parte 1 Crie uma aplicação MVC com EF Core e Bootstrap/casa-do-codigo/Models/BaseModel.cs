using System;
using System.Runtime.Serialization;

namespace casa_do_codigo.Models
{
    [DataContract]    
    public class BaseModel
    {
        [DataMember]
        public int Id{get; protected set;}
        
    }
}