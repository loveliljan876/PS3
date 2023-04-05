namespace PS3.Pages.Forms
{
    public class YearResponse
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public bool IsLeapYear()
        {
            return DateTime.IsLeapYear(Year);
        }

        public bool IsFemale()
        {
            return Name.EndsWith('a');
        }

        public YearResponse(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Name} urodzil{(IsFemale() ? "a" : "")} sie w {Year} roku. To {(IsLeapYear() ? "" : "nie")} byl rok przestepny.";
        }
    }
}
