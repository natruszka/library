using library.Entities;

namespace library.Services.Interfaces;

public interface IPublisherService
{
    ICollection<Publisher> GetAllPublishers();
    Task AddNewPublisher(String name);
}