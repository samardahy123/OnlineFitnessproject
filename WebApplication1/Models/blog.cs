//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class blog
    {
        public int id { get; set; }
        public string title { get; set; }
        public string blog_im { get; set; }
        public string blog_content { get; set; }
        public Nullable<int> adblog { get; set; }
    
        public virtual admin_for_blogerr admin_for_blogerr { get; set; }
    }
}
