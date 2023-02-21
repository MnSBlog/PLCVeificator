using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace TimeChartEditor
{
    class EventTable
    {
        public List<string> keys = new List<string>();
        public List<List<int>> events = new List<List<int>>();
        public List<string> address = new List<string>();
        public int interval;
    }
    internal class EventHandler
    {
        private EventTable _eventTable = new EventTable();
        public EventHandler(string path)
        {
            var chart = FileController.Instance.DeSerialize<EventTable>(path);
            _eventTable = chart;
        }
        public bool ResetEventTable()
        {
            return true;
        }
        public List<int> GetEvents(int index)
        {
            if (_eventTable.events.Count <= index && index < 0)
                return new List<int>();
            return _eventTable.events[index];
        }
        public int GetEventsLength()
        {
            return _eventTable.events.Count;
        }
        public List<string> GetKeys() { return _eventTable.keys; }
        public List<string> GetAddress() { return _eventTable.address; }
    }
}
