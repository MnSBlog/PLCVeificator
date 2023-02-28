using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    public class LangMatcher
    {
        private List<MemoryTerm> _cimMessage = new List<MemoryTerm>();
        private static readonly string HIERACHY = "LBU";

        public List<MemoryTerm> ShowAll()
        {
            return _cimMessage;
        }

        public string GetItem(List<string> tags)
        {
            // 숫자가 증가할수록 Level은 낮아진다.
            int count = tags.Count;
            if (count == 0)
                return "INVALID ARGUMENTS";

            List<MemoryTerm> target = _cimMessage;
            string rtnMsg = "";
            for (int pivot = 0; pivot < count; ++pivot)
            {
                (int index, string msg) = CompareTag(target, tags[pivot]);
                rtnMsg = msg;
                if (index < 0)
                {
                    return rtnMsg;
                }
                else
                {
                    target = target[index].Child;
                }
            }
            return rtnMsg;
        }

        public void AddTerm(string line, string tag)
        {

            var term = MakeTerm(line, tag);
            int pivot = HIERACHY.IndexOf(tag);
            
            // L 일경우
            if (pivot == 0)
                _cimMessage.Add(term);
            else
            {
                // B일 경우
                var root = _cimMessage.Last();
                term.Root = root;
                if (pivot != HIERACHY.Length - 1)
                    _cimMessage.Last().Child.Add(term);
                else
                {
                    // U일 경우
                    var leaf = root.Child.Last();
                    _cimMessage.Last().Child.Last().Child.Add(term);
                }
            }
        }
        private (int, string) CompareTag(List<MemoryTerm> target, string tag)
        {
            for (int itr = 0; itr < target.Count; ++itr)
            {
                var obj = target[itr];
                if (obj.Bit.Equals(tag))
                {
                    return (itr, obj.Value);
                }
            }
            return (-1, "NOT FOUND");
        }
        private MemoryTerm MakeTerm(string line, string tag)
        {
            MemoryTerm term = new MemoryTerm();
            var begin = line.IndexOf(tag);
            var end = line.IndexOf(" ");
            var bitLength = end - begin;
            term.Bit = line.Substring(begin, bitLength);
            end = line.IndexOf(">");
            term.Value = line.Substring(begin + bitLength + 1, end - (begin + bitLength + 1));
            return term;
        }

        public class MemoryTerm
        {
            public string Bit { get; set; }
            public string Value { get; set; }
            public MemoryTerm Root;
            public List<MemoryTerm> Child = new List<MemoryTerm>();
        }
    }
}
