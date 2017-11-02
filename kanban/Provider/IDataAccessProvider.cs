using Provider.Model;
using System.Collections.Generic;

namespace Provider
{
    public interface IDataAccessProvider
    {
        void AddDataEventRecord(Tasks dataEventRecord);
        void UpdateDataEventRecord(int dataEventRecordId, Tasks dataEventRecord);
        void DeleteDataEventRecord(int dataEventRecordId);
        List<Tasks> GetDataEventRecords();
        Tasks GetDataEventRecord(int dataEventRecordId);
    }
}
