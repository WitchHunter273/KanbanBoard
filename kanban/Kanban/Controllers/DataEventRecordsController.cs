using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Provider;
using Provider.Model;

namespace Kanban.Controllers
{
    [Produces("application/json")]
    [Route("api/DataEventRecords")]
    public class DataEventRecordsController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;


        public DataEventRecordsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet("[action]")]
        public IEnumerable<Tasks> GetTasks()
        {
            return _dataAccessProvider.GetDataEventRecords();
        }


        [HttpGet("{id}")]
        public Tasks GetTask(int id)
        {
            return _dataAccessProvider.GetDataEventRecord(id);
        }

        [HttpPost]
        public void Post([FromBody]Tasks value)
        {
            _dataAccessProvider.AddDataEventRecord(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Tasks value)
        {
            _dataAccessProvider.UpdateDataEventRecord(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dataAccessProvider.DeleteDataEventRecord(id);
        }
    }
}