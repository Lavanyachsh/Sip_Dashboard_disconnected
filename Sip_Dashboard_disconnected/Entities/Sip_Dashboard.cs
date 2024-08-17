namespace Sip_Dashboard_disconnected.Entities
{
    public class Sip_Dashboard
    {
        public int position { get; set; }
        public string name { get; set; }
        public decimal weight {  get; set; }
        public string symbol { get; set; }
        public string location { get; set; }
    }
}

//position int identity(1,1),name varchar(max),weight decimal,symbol varchar(10),
//location varchar(max))