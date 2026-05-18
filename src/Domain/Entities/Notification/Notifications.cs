using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

public class Notifications
{
    public Notifications()
    {
        notification = new List<Notifications>();
    }

    [JsonIgnore]
    [NotMapped]
    public string? NameProperties{ get; set; }

    [JsonIgnore]
    [NotMapped]

    public string? message { get; set; }

    [JsonIgnore]
    [NotMapped]
    List<Notifications>? notification {get; set;}


    public bool ValidatePropertiesString(string value, string nameProperties)
    {
        if(string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(nameProperties))
        {
            notification.Add(new Notifications {
                message = "d",
                NameProperties = "d"
            });
            return false; 
        }
            return true;
    }


}