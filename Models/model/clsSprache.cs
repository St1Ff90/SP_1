using System.Collections.Generic;
using static Sprache.Models.model.clsDeutschContentLibrary;

namespace Sprache.Models.model
{
    public class clsSprache
    {
        clsDeutschContentLibrary contentLibrary = new clsDeutschContentLibrary();
        public clsSprache() 
        {
            foreach(string[] gram in contentLibrary.Grammatik)
            {

            }
        }
    }
}
