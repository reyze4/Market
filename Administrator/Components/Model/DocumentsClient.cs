//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Administrator.Components.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DocumentsClient
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public int ClientID { get; set; }
        public int SeriesPassport { get; set; }
        public int NumberPassport { get; set; }
    
        public virtual Client Client { get; set; }
    }
}