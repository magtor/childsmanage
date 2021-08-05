using SchoolSundayRH.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSundayRH.Repository
{
    public class PatherRepository
    {
        private Models.misionestiContext dbSchoolSunday = new Models.misionestiContext();
        public List<Childs> GetChilds(int CountPather)
        {
            List<Childs> lstchilds = null;
            if (CountPather == 0)
            {
                //llenar con toda la lista de hijos
                lstchilds = (from ch in dbSchoolSunday.Childs
                             select new Childs
                             {
                                 Childid = ch.Childid,
                                 Nombre1 = ch.Nombre1

                             }
                              ).ToList();

            }
            else
            {
                //llenar la lista exceptuando el hijo que ya esta asociado a este padre
                //si incluimos el Where lefthijosout.Padreid == id , nos dara la lista de hijos 
                //asociados al id del padre
                lstchilds = (from hijos in dbSchoolSunday.Childs
                             join patherson in dbSchoolSunday.Padreshijos on hijos.Childid equals patherson.Childid
                             into lefthijos
                             from lefthijosout in lefthijos.DefaultIfEmpty()
                             where lefthijosout.Childid == null
                             select new Childs
                             {
                                 Childid = hijos.Childid,
                                 Nombre1 = hijos.Nombre1

                             }).ToList();
            }
            return lstchilds;
        }
        public List<Padres> GetPadre(uint idPadre)
        {
            List<Padres> listPadres = null;
            listPadres = (from pt in dbSchoolSunday.Padres
                          where pt.Padreid == idPadre
                          select new Padres
                          {
                              Padreid = pt.Padreid,
                              Nombre1 = pt.Nombre1

                          }
                         ).ToList();
            return listPadres;
        }
        public List<Childs> GetListSonFromPather(uint idPadre)
        {
            List<Childs> lstchilds = null;
            lstchilds = (from hijos in dbSchoolSunday.Childs
                         join patherson in dbSchoolSunday.Padreshijos on hijos.Childid equals patherson.Childid
                         where patherson.Padreid == idPadre                                               
                         
                         select new Childs
                         {
                             Childid = hijos.Childid,
                             Nombre1 = hijos.Nombre1

                         }).ToList();
        

            return lstchilds;
        }
    }

}
