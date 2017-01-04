using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class Cultureitem
    {
        public string title;
        public string description_EN;
        public string description_NL;
        public string poster;
        public string street;
        public string streetnumber;
        public string contact;
        public string maps;
        public string openinghours1_EN;
        public string openinghours2_EN;
        public string openinghours1_NL;
        public string openinghours2_NL;

        public Cultureitem(string title, string description_EN, string description_NL, string poster, string street, string streetnumber, string contact, string maps, string openinghours1_EN, string openinghours2_EN, string openinghours1_NL, string openinghours2_NL)
        {
            this.title = title;
            this.description_EN = description_EN;
            this.description_NL = description_NL;
            this.poster = poster;
            this.street = street;
            this.streetnumber = streetnumber;
            this.contact = contact;
            this.maps = maps;
            this.openinghours1_EN = openinghours1_EN;
            this.openinghours2_EN = openinghours2_EN;
            this.openinghours1_NL = openinghours1_NL;
            this.openinghours2_NL = openinghours2_NL;
        }

        public Cultureitem()
        {
        }
    }
}