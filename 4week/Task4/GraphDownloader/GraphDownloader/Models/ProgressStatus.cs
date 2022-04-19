using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDownloader.Models
{

    public class ProgressStatus : IProgress<int>
    {
        Action<int> action;
        public ProgressStatus(Action<int> progressAction) =>
            action = progressAction;

        public void Report(int value) => action(value);
    }

}
