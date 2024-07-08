using AppsettingsWpf.DAL.Entityes.Base;

namespace AppsettingsWpf.DAL.Entityes
{
    public class Picture : NamedEntity
    {
        // Свойства Id, Name находятся в базоввом классе.

        public int? DealId { get; set; }
        
        public Deal Deal { get; set; }
    }
}
