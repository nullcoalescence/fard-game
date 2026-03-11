using System.Text;

namespace fardgame.models
{
    /// <summary>
    /// For now, cards will be pretty simple.
    /// They will have a name, health, and attack value.
    /// </summary>
    public class Card
    {
        public required string Name { get; set; }
        public required int Attack { get; set; }
        public required int Health { get; set; }


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("************************");
            stringBuilder.AppendLine($"* Name {Name}");
            stringBuilder.AppendLine($"* Attack: {Attack}");
            stringBuilder.AppendLine($"* Health: {Health}");
            stringBuilder.AppendLine("************************");
            return stringBuilder.ToString();
        }
    }
}
