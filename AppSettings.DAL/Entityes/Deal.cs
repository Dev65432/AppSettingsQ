﻿using AppsettingsWpf.DAL.Entityes.Base;
using System.Collections.Generic;


namespace AppsettingsWpf.DAL.Entityes
{    
    public class Deal : NamedEntity 
    {
        // Свойства Id, Name находятся в базоввом классе.

        public ICollection<Picture> Pictures { get; set; }

        public Deal()
        {
            Pictures = new List<Picture>();
        }
    }
}

