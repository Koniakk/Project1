using Newtonsoft.Json;

namespace Project1.Core
{
    public class Country
    {
        public static int _id_counter = 0;
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

        [JsonProperty("ItemId")]
        public int ItemId { get; set; }

        public string Title { get; set; }


        public override string ToString()
        {
            return ItemId + "|" + Title;
        }
    }
}
