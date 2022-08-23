using Application.Common.Interfaces;
using Application.Dictionaries;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MainIndex
{
    public class GetIssues : IIndex
    {
        public IEnumerable<KeyValuePair<string, string>> IssueKeyValue { get; }

        public GetIssues()
        {
            IssueKeyValue = from name in Enum.GetNames(typeof(Issues))
                            join nameSk in IssuesSk.IssuesList
                            on name equals nameSk.Key
                            select nameSk;
        }
    }
}
