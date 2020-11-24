using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace TT.Diary.WebAPI
{
    public class BaseDbCommandInterceptor : DbCommandInterceptor
    {
        private readonly string DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            FormatParameters(command.Parameters);
            return base.ReaderExecuting(command, eventData, result);
        }

        public override Task<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            FormatParameters(command.Parameters);
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        private void FormatParameters(DbParameterCollection parameters)
        {
            foreach (var parameter in parameters)
            {
                var p = parameter as SqliteParameter;

                if (p == null)
                {
                    continue;
                }

                if (p.Value is DateTime)
                {
                    p.Value = ((DateTime)p.Value).ToString(DATE_TIME_FORMAT);
                }
            }
        }
    }
}
