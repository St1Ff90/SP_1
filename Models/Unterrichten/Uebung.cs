namespace SP.Models.Unterrichten
{
    public class Uebung
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UnterthemaId { get; set; }

        public virtual Unterthema? Unterthema { get; set; }

        public string? Aufgabe { get; set; }

        public string? Frame { get; set; }

        public string? Text { get; set; }

        public string? Antworten { get; set; }

    }
}
