using POSWebApp.Utilities;
using System.ComponentModel.DataAnnotations;

namespace POSWebApp.Models.Entities;

public class BaseEntity
{
    [Key]
    public string Id { get; set; }//primary key for database
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public string IpAddress { get; set; } = NetworkHelper.GetLocalIPAddress();//getting the local ip address of machine
    public bool IsInActive { get; set; }
}
