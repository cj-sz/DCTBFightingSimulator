using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCTBFightingSimulator
{
    class ImportExportString
    {
        /*Import / Export String Class
         * This class can get data from a variety of fields by being called from certain methods and buttons in the character creation interface.
         * It generates a prodecural string, which can then be exported, and then read by the character class.
         * All fields must be filled out to generate a string.
         * See the main method for details.
         */

        private string importExportString;

        public ImportExportString()
        {
            //Empty constructor, done by methods below.
        }

        public void generateString()
        {

        }
        public string getImportExportString()
        {
            return importExportString;
        }
    }
}
