namespace SPV_REST.Models
{
    public class Person
    {
        public int Id { get; set; } //The Id field is required by the database for the primary key.
        public string? Pn { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTime Fom { get; set; }
        public DateTime Tom { get; set; }
        public string? Salary { get; set; }

    }
}
