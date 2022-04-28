using System;
using System.Collections.Generic;
using System.Text;

namespace SortAndSearch
{
    public class RandomNumberGenerationItems
    {
        public int Index { get; set; }
        public int Length { get; set; }

        public RandomNumberGenerationItems(int index, int length)
        {
            this.Index = index;
            this.Length = length;
        }
    }
}
