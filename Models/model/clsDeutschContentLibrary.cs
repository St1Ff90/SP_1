namespace Sprache.Models.model
{
    public class clsDeutschContentLibrary
    {
        public List<string[]> Grammatik { get; set; }
        public List<string[]> Wortschatz { get; set; }

        public clsDeutschContentLibrary()
        {
            Grammatik = new List<string[]>
            {
             new string[] {"Verben und Personal pronomen", Niveau.A1.ToString(), "", "", "", ""},
             new string[] {"Verben und Konjugation Präsens", Niveau.A1.ToString(), "", "", "", ""},
             new string[] {"Verben sein haben möchten mögen wissen tun", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Verben mit Vokalwechsel", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Verben Modelverben Konjugation Position im Satz", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Verben Modalverben Gebrauch1", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Verben Modalverben Gebrauch2", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Trennbare Verben", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Imperativ", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Fragen mit Fragewort", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Ja/nein Fragen", Niveau.A1.ToString(), "", "", "", "" },
             new string[] {"Verb Position", Niveau.A1.ToString(), "", "", "", "" }
            };
            Wortschatz = new List<string[]>
        {
            new string[] {"Kontakte Informationen zu Person", Niveau.A1.ToString(),Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(),Niveau.C1.ToString()},
            new string[] {"Mensch", Niveau.A1.ToString(),Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(),Niveau.C1.ToString()},
            new string[] {"Familie Freunde", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() },
            new string[] {"Körper Körperpflege", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() },
            new string[] {"Gesundheit Krankheit", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() },
            new string[] {"Wahrnehmung Aktivitäten", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() },
            new string[] {"Wohnen Hausarbeit", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() },
            new string[] {"Umwelt Natur", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() },
            new string[] {"Reisen Verkehr", Niveau.A1.ToString(), Niveau.A2.ToString(), Niveau.B1.ToString(), Niveau.B2.ToString(), Niveau.C1.ToString() }
        };
        }
        public enum Niveau
        {
            A1,
            A2,
            B1,
            B2,
            C1
        }
    }
}
