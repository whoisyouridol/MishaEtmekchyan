using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobService.Abstractions
{
    public interface IBackgroundJobService
    {
        Task SynchronizeAsync();
    }
}
