﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoMVC.Domain
{
    public class DTOToDo
    {
        public string Name { get; set; }
        public IList<DTOItem> Items { get; set; }
    }
}