using MenuConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Helpers
{
    public class PageCalculator
    {
        public int CountAmountOfPages(List<CommonItemModel> listOfElements, int pageSize) 
        {
            int amountOfPages = 0;

            int amountOfPositionOnList = listOfElements.Count;
            if (amountOfPositionOnList <= 10)
            {
                amountOfPages = 1;
            }
            else
            {
                amountOfPages = amountOfPositionOnList % pageSize;
                if (amountOfPages != 0)
                {
                    amountOfPages = (amountOfPositionOnList / pageSize) + 1;
                }
                else
                {
                    amountOfPages = amountOfPositionOnList / pageSize;
                }
            }

            return amountOfPages;
        }
    }
}
