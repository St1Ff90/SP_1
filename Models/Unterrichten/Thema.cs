namespace SP.Models.Unterrichten
{
    public class Thema
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Bereich Bereich { get; set; }

        public string? ThemaName { get; set; }

        public virtual List<Unterthema>? UnterthemenList { get; set; }

        public override string ToString()
        {
            return ThemaName != null ? ThemaName : string.Empty;
        }
    }
    public enum Bereich
    {
        None = 0,
        Grammatik = 1,
        Wortschatz = 2
    }
}
