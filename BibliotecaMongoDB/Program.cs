using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using BibliotecaMongoDB;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");

        var basededados = mongo.GetDatabase("biblioteca");
        var collection = basededados.GetCollection<BsonDocument>("livro");
        var documents = collection.Find(new BsonDocument()).ToList();

        //encontrar um livro na biblioteca:
        //Console.WriteLine("Informe o título do livro: ");
        //string t = Console.ReadLine();
        //var filtro = Builders<BsonDocument>.Filter.Regex("titulo", t);
        //var l = collection.Find(filtro).FirstOrDefault();
        //var livro = BsonSerializer.Deserialize<Livro>(l);
        //Console.WriteLine("\n" + livro.ToString());


        //alterar a editora do livro:
        //Console.WriteLine("Informe o título do livro: ");
        //string t = Console.ReadLine();
        //var l = collection.Find(Builders<BsonDocument>.Filter.Regex("titulo", t)).First();
        //var livro = BsonSerializer.Deserialize<Livro>(l);
        //Console.WriteLine("Informe a nova editora: ");
        //string e = Console.ReadLine();
        //livro.Editora = e;
        //var filtro = Builders<BsonDocument>.Filter.Regex("titulo", t);
        //var update = Builders<BsonDocument>.Update.Set("editora", e);
        //collection.UpdateOne(filtro, update);


        //excluir um livro da biblioteca:
        //Console.WriteLine("Informe o título do livro: ");
        //string t = Console.ReadLine();
        //var filtro = Builders<BsonDocument>.Filter.Regex("titulo", t);
        //collection.FindOneAndDelete(filtro);


        //listar os livros da biblioteca:
        //foreach (var livro in documents)
        //{
        //    Console.WriteLine(livro.ToString());
        //    Console.ReadLine();
        //}


        //inserir um livro na biblioteca:
        Console.WriteLine("ISBN: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Título: ");
        string t = Console.ReadLine();

        Console.WriteLine("Editora: ");
        string e = Console.ReadLine();

        Console.WriteLine("Ano de publicação: ");
        int a = int.Parse(Console.ReadLine());

        Livro livro = new(n, t, e, a);
        Console.WriteLine(livro.ToString());
        var l = new BsonDocument
        {
            {"isbn", livro.ISBN},
            {"titulo", livro.Titulo},
            {"editora", livro.Editora},
            {"ano publicacao", livro.AnoPublicacao},
        };
        Console.WriteLine(l);
        collection.InsertOne(l);
    }
}