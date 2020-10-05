using RaceAssessment.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceAssessment
{
    class Factory
    {

        public static int PunterNum { get; set; }

        public static Punter GetAPunter(int id)
        {
            switch (id)
           {
               case 0:
                    return new Joel();
                case 1:
                    return new Arnald();
                case 2:
                    return new Jeff();
                default:
                    return null;
            }
        }

        public static int SetPunterNumber(string Name)
        {
            switch (Name) 
            {
                case "Joel":
                  PunterNum = 0;
                    return PunterNum;
                case "Jeff":
                    PunterNum = 1;
                    return PunterNum;
                case "Arnald":
                    PunterNum = 2;
                    return PunterNum;
                default:
                    PunterNum = 0;
                    return PunterNum;




            }



        }
    }
}
