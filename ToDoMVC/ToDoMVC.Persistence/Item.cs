//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoMVC.Persistence
{
    /// Responsibilities:
    /// TODO Data Object
    /// responsible to get and set Database values.
    /// Here the User and the TODO value will be linked
    /// and accessed.
    
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public string Name { get; set; }
        public string ToDoName { get; set; }
        public virtual ToDo ToDo { get; set; }
    }
}
