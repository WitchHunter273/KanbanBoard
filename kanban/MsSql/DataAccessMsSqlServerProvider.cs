using System;
using System.Linq;
using System.Collections.Generic;
using Provider;
using Microsoft.Extensions.Logging;
using Provider.Model;

namespace Mssql
{
    public class DataAccessMsSqlServerProvider : IDataAccessProvider
    {
        private readonly DomainModelMsSqlServerContext _context;
        private readonly ILogger _logger;

        public DataAccessMsSqlServerProvider(DomainModelMsSqlServerContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessMsSqlServerProvider");

        }

        public List<Tasks> GetDataEventRecords()
        {
            return _context.Tasks.OrderByDescending(dataEventRecord => dataEventRecord.Id).ToList();
        }

        public void AddDataEventRecord(Tasks dataEventRecord)
        {
            _context.Tasks.Add(dataEventRecord);
            _context.SaveChanges();
        }

        public void UpdateDataEventRecord(int dataEventRecordId, Tasks dataEventRecord)
        {
            _context.Tasks.Update(dataEventRecord);
            _context.SaveChanges();
        }

        public void DeleteDataEventRecord(int dataEventRecordId)
        {
            var entity = _context.Tasks.First(t => t.Id == dataEventRecordId);
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
        }

        public Tasks GetDataEventRecord(int dataEventRecordId)
        {
            return _context.Tasks.First(t => t.Id == dataEventRecordId);
        }

    }
}
