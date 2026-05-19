using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;

public class Notifications
{
    public Notifications()
    {
        NotificationList = new List<Notifications>();
    }

    [JsonIgnore]    
    [NotMapped]
    public string? PropertyName{ get; set; }

    [JsonIgnore]
    [NotMapped]

    public string? Message { get; set; }

    [JsonIgnore]
    [NotMapped]
    
    public List<Notifications> NotificationList {get; private set;}

    public void AddNotification (string property, string message)
    {
        NotificationList.Add(new Notifications{
                PropertyName = property,
                Message = message
        }); 
    }
    public bool ValidatePropertiesString(string value, string PropertyName)
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            NotificationList.Add(new Notifications {
                Message = "Field {propertyName} is required",
                PropertyName = PropertyName
            });
            return false; 
        }
            return true;
    }

        public bool ValidatePropertiesInt(int value, string PropertyName)
    {
        if(value <= 0 )
        {
            NotificationList.Add(new Notifications {
                Message = "Field {propertyName} is invalid",
                PropertyName = PropertyName
            });
            return false; 
        }
            return true;
    }

    
        public bool ValidatePropertiesGuidId(Guid id, string PropertyName)
    {
        if(id == Guid.Empty )
        {
            NotificationList.Add(new Notifications {
                Message = "Field {propertyName} is required",
                PropertyName = PropertyName
            });
            return false; 
        }
            return true;
    }
    
       public bool ValidatePropertiesDecimal(Decimal value, string PropertyName)
    {
        if(value <= 0 )
        {
            NotificationList.Add(new Notifications {
                Message = "Field {propertyName} is required",
                PropertyName = PropertyName
            });
            return false; 
        }
            return true;
    }
    


}