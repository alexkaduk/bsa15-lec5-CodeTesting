using System.Collections.Generic;
using System.Linq;

namespace BookHelper
{
    internal class Book
    {
        private readonly List<PagesRange> _readPages = new List<PagesRange>();

        public readonly int PagesCount;

        public Book(int pagesCount)
        {
            PagesCount = pagesCount;
        }

        public void AddRange(int from, int to)
        {
            _readPages.Add(new PagesRange(from, to));
        }

        public int HowManyPagesLeft()
        {
            // TODO 3: Improve/fix the code here.
            //var readPages = 0;
            //for (var page = 1; page <= PagesCount; page++)
            //{
            //    foreach (var range in _readPages)
            //    {
            //        if (page >= range.From && page <= range.To)
            //        {
            //            readPages++;
            //        }
            //    }
            //}

            var readPagesList = new List<int>();
            foreach (var range in _readPages)
            {
                for (var i = range.From; i <= range.To; i++)
                {
                    readPagesList.Add(i);
                }
            }

            var leftPages = PagesCount - readPagesList.Distinct().Count();

            return leftPages;
        }
    }
}
