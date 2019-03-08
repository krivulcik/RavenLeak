using Raven.Client.Documents;

namespace RavenLeak
{
    class Program
    {
        static void Main(string[] args)
        {
            // database needs to exist, no data necessary
            var documentStore = new DocumentStore
            {
                Urls = new[] { "http://live-test.ravendb.net" },
                Database = "RavenLeak",
            };

            documentStore.Initialize();

            using (var session = documentStore.OpenSession())
            {
                var company = session.Load<Company>("companies/91-A");
            }
        }
    }

    class Company
    {
        public string Id { get; set; }
    }
}
