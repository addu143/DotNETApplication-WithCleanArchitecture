using Microsoft.Extensions.Logging;
using ReadingIsGood.Core.DBEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogLevel = ReadingIsGood.Core.DBEntities.LogLevel;

namespace ReadingIsGood.Core.Interfaces
{
    public interface ILogService
    {
        Task<Log> InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "", CancellationToken cancellationToken = default);
        Task<List<Log>> GetAll();

    }
}