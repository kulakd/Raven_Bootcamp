using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using RavenAPI.Models;
using System.Globalization;

namespace RavenAPI.Data
{
    public static class RavenExtensions
    {
        public static async Task SeedData(this IAsyncDocumentSession session)
        {
            var cultureInfo = new CultureInfo("pl-PL");
            var query = from Movie in session.Query<Movie>() select Movie;
            var result = await query.ToListAsync();
            if (result.Count != 0) return;

            var movies = new List<Movie>
            {
                new Movie()
                {
                    Title= "Title",
                    Director = "Director",
                    Studio = "Studio",
                    Premiere = DateTime.Parse("1 stycznia 1998", cultureInfo),
                    Category= "Category",
                    Description = "Description",
                    MovieDetails = new MovieDetails
                    {
                        Amount = 1,
                        Borrowed = 0
                    }
                },
                new Movie()
                {
                    Title= "Ołowiany Świt",
                    Director = "Michał Gołkowski",
                    Studio = "Fabryka Słów",
                    Premiere = DateTime.Parse("26 kwietnia 2013", cultureInfo),
                    Category= "Fantastyka",
                    Description = "Zona - tajemnica, która wciąga, kusi i intryguje.\r\n\r\nJej historią jest świat współczesny. Jej dzieci to my.\r\n\r\nUniwersum S.T.A.L.K.E.R.a oczami Polaka – stara mleczarnia, martwy cieć, zapomniany kalendarz i wieża w środku lasu.\r\n\r\nWchodzisz w to? Zresztą, już jesteś. Wszyscy jesteśmy – stalkerami. Dziećmi Sarkofagu.\r\n\r\nTutaj wrogiem jest zło, które może czaić się tuż obok, za naszymi plecami. Może przyjmować różne postaci, imiona i kształty; jednak najstraszniejszym, co możemy spotkać w Zonie - jest człowiek.\r\n\r\nWstaje nowy dzień. Czy przeżyjesz go - całym sobą?",
                    MovieDetails = new MovieDetails
                    {
                        Amount = 100,
                        Borrowed = 0
                    }
                },
                new Movie()
                {
                    Title= "Stalowe Szczury. Błoto",
                    Director = "Michał Gołkowski",
                    Studio = "Fabryka Słów",
                    Premiere = DateTime.Parse("1 stycznia 2015", cultureInfo),
                    Category= "Fantastyka",
                    Description = "Wiosna 1922. Samobójcze natarcie na pozycje przeciwnika po raz kolejny prowadzi kapral Reinhardt i jego kompania karna – kundle wojny, dezerterzy, podpalacze i najgorsze szumowiny. Straceńcy gotowi na wszystko.",
                    MovieDetails = new MovieDetails
                    {
                        Amount = 150,
                        Borrowed = 0
                    }
                },
                new Movie()
                {
                    Title= "Komornik",
                    Director = "Michał Gołkowski",
                    Studio = "Fabryka Słów",
                    Premiere = DateTime.Parse("1 stycznia 2016", cultureInfo),
                    Category= "Fantastyka",
                    Description = "Nadchodzi Koniec.\r\nAle taki w cholerę prawdziwy, biblijny. Ziemia zatrzymuje się, gwiazdy spadają, woda zamienia się w krew. Umarli wstają z grobów, otwiera się otchłań. Państwa upadają, brat powstaje przeciw bratu, a dzieci podnoszą rękę na rodziców. Widać, że lada chwila świat spłonie.\r\nTylko że coś w systemie nie zaskoczyło. Generalnie, zasadniczo i pobieżnie: zamiast bomby termojądrowej wychodzi fajerwerk.",
                    MovieDetails = new MovieDetails
                    {
                        Amount = 80,
                        Borrowed = 0
                    }
                }
            };

            foreach (var Movie in movies)
            {
                await session.StoreAsync(Movie);
            };
            await session.SaveChangesAsync();
        }
    }
}
