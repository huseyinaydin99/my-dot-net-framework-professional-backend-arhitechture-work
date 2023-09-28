namespace AydinCompany.Core.CrossCuttingConcerns.Logging
{
    //Log data'sını tutacak bir nesne.
    public class LogParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
    }
}
