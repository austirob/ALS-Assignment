using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxGamesUI.Static
{
    class RatingOptions : List<int>
    {

        // only allowing users to vote in whole numbers
         public RatingOptions()
        {
            
            Add(1);
            Add(2);
            Add(3);
            Add(4);
            Add(5);
        }
    }
}
