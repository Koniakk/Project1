
using Newtonsoft.Json;
using Project1.Core.Entity;
using Project1.Entity;




namespace Project1.Core
{
    public class Country : IdentifiableEntity
    {
        public static int _id_counter = 0;
        private const bool IsNameRequired = true;

        /// <summary>
        /// Обычный конструктор, до .NET8. В новых версиях доступны оба варианта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        public Country(string title = "all country")
        {
            ItemId = _id_counter++;
            Title = title;
        }



        internal class Configuration() : Configuration<Country>()
        {
            public override void Configure(EntityTypeBuilder<Country> builder)
            {
                builder.Property(country => country.Name)
                .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }


        [JsonProperty("ItemId")]
        public int ItemId { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return ItemId + "|" + Title;
        }



        public string? Name { get; set; } = string.Empty;
        public List<Country> Articles { get; set; } = [];
    }

    

}
