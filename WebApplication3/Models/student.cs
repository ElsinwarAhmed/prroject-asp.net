//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        public int student_id { get; set; }
        public string student_name { get; set; }
        public string student_age { get; set; }
        public Nullable<int> course_id { get; set; }
    
        public virtual course course { get; set; }
    }
}
