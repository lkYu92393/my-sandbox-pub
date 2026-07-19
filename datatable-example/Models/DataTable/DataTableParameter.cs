namespace DataTableTest.Models.DataTable
{
    public class DataTableParameter
    {
        public int draw { get; set; }
        public List<DataTableColumns> columns { get; set; }
        public List<DataTableOrder> order { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public DataTableSearch search { get; set; }

        public DataTableParameter() { }
        public DataTableParameter(Dictionary<string, string> dict)
        {
            draw = int.Parse(dict["draw"]);
            columns = DataTableColumns.ParseList(dict);
            order = DataTableOrder.ParseList(dict);
            start = int.Parse(dict["start"]);
            length = int.Parse(dict["length"]);
            search = new DataTableSearch(dict);
        }
    }

    public class DataTableColumns
    {
        public string data { get; set; }
        public object name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTableSearch search { get; set; }
        public DataTableColumns() { }
        public DataTableColumns(Dictionary<string, string> dict, string prefix)
        {
            data = dict[$"{prefix}[data]"];
            name = dict[$"{prefix}[name]"];
            searchable = bool.Parse(dict[$"{prefix}[searchable]"]);
            orderable = bool.Parse(dict[$"{prefix}[orderable]"]);
            search = new DataTableSearch(dict, $"{prefix}[search]");
        }
    
        public static List<DataTableColumns> ParseList(Dictionary<string, string> dict)
        {
            List<DataTableColumns> list = new();
            List<string> keys = dict.Keys.Where(key => key.StartsWith("columns")).ToList();
            for (int i = 0; i * 6 < keys.Count; i++)
            {
                list.Add(new DataTableColumns(dict, $"columns[{i}]"));
            }
            return list;
        }
    }

    public class DataTableSearch
    {
        public string value { get; set; }
        public bool regex { get; set; }
        public DataTableSearch() { }
        public DataTableSearch(Dictionary<string, string> dict, string prefix = "search")
        {
            value = dict[$"{prefix}[value]"];
            regex = bool.Parse(dict[$"{prefix}[regex]"]);
        }
    }

    public class DataTableOrder
    {
        public string column { get; set; }
        public string dir { get; set; }
        public string name { get; set; }
        public DataTableOrder() { }
        public DataTableOrder(Dictionary<string, string> dict, string prefix)
        {
            column = dict[$"{prefix}[column]"];
            dir = dict[$"{prefix}[dir]"];
            name = dict[$"{prefix}[name]"];
        }
    
        public static List<DataTableOrder> ParseList(Dictionary<string, string> dict)
        {
            List<DataTableOrder> list = new();
            List<string> keys = dict.Keys.Where(key => key.StartsWith("order")).ToList();
            for (int i = 0; i * 3 < keys.Count; i++)
            {
                list.Add(new DataTableOrder(dict, $"order[{i}]"));
            }
            return list;
        }
    }
}
