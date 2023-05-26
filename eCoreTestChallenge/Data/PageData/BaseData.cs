using eCoreTestChallenge.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCoreTestChallenge.Data.PageData
{
    public record BaseData
    {
        public BaseData()
        {
            Reporter.SetTestData(this);
        }
    }
}