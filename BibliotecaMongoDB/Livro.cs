using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BibliotecaMongoDB
{
    [BsonIgnoreExtraElements]
    internal class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("isbn")]
        [BsonRepresentation(BsonType.Int32)]
        public int ISBN { get; set; }

        [BsonElement("titulo")]
        public string? Titulo { get; set; }

        [BsonElement("editora")]
        public string? Editora { get; set; }

        [BsonElement("ano publicacao")]
        [BsonRepresentation(BsonType.Int32)]
        public int AnoPublicacao { get; set; }

        public Livro(int isbn, string? titulo, string? editora, int ano_publicacao)
        {
            ISBN = isbn;
            Titulo = titulo;
            Editora = editora;
            AnoPublicacao = ano_publicacao;
        }


        public override string ToString()
        {
            return $"ISBN: {ISBN}\nTítulo: {Titulo}\nEditora: {Editora}\nAno de publicação: {AnoPublicacao}\n";
        }
    }
}
